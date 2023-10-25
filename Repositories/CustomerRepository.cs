using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.DTOs;
using PruebaTecnicaSofftek.Helpers;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Repositories.Interfaces;

namespace PruebaTecnicaSofftek.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Customer updateCustomer)
        {
            var Customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == updateCustomer.CustomerId);
            if (Customer == null) { return false; }

            Customer.CustomerName = updateCustomer.CustomerName;
            Customer.Email = updateCustomer.Email;
            Customer.Password = updateCustomer.Password;
            _context.Customers.Update(Customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var service = await _context.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            if (service != null)
            {
                _context.Customers.Remove(service);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Customer newCustomer)
        {
            try
            {
                var customerExisting = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == newCustomer.CustomerId);

                if (customerExisting != null)
                {
                    return false;
                }

                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Customer?> AuthenticateCredentials(AutenticacionDto dto)
        {
            return await _context.Customers.SingleOrDefaultAsync
                (x => x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email));
        }
    }
}
