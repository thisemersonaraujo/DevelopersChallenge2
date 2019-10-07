using AutoMapper;
using BankingConciliation.Domain.Entities;
using BankingConciliation.Web.Models;

namespace BankingConciliation.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region [ Transaction ]

            Mapper.CreateMap<Transaction, TransactionModel>();

            #endregion
        }
    }
}