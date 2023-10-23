using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSofftek.DataAccess;
using PruebaTecnicaSofftek.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Linq;

namespace PruebaTecnicaSofftek.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            //return await _context.Set<T>().ToListAsync();
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public async Task<T> GetById(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }


        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
