using BankingConciliation.Domain.Contracts.Repositories;
using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingConciliation.Infra.Repositories
{
    public class TransactionRepository
        : BaseRepository<Transaction, Guid>, ITransactionRepository
    {
    }
}
