using AutoMapper;
using PruebaTecnicaSofftek.DTOs;
using PruebaTecnicaSofftek.Models;

namespace PruebaTecnicaSofftek
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            // Mapeo de las clases a sus DTOs
            // Hace conversiones
            CreateMap<Account, AccountDto>().ReverseMap();

            CreateMap<BankAccount, BankAccountDto>().ReverseMap();

            CreateMap<CryptoAccount, CryptoAccountDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Transfer, TransferDto>().ReverseMap();
        }
    }
}
