using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BankingConciliation.Domain.Contracts.Repositories
{
    public interface ITransactionRepository
        : IBaseRepository<Transaction, Guid>
    {
    }
}
