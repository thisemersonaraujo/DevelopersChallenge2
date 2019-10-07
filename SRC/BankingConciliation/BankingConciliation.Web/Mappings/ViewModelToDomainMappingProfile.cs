using AutoMapper;
using BankingConciliation.Domain.Entities;
using BankingConciliation.Web.Models;

namespace BankingConciliation.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region [ Transaction ]

            Mapper.CreateMap<TransactionModel, Transaction>();

            #endregion
        }
    }
}