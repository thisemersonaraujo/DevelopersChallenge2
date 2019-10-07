using BankingConciliation.Domain.Entities;
using System;

namespace BankingConciliation.Domain.Contracts.Services
{
    public interface ITransactionDomainService
        : IBaseDomainService<Transaction, Guid>
    {
    }
}
