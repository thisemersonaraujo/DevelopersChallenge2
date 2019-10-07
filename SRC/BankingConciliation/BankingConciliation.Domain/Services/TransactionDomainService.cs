using BankingConciliation.Domain.Contracts.Repositories;
using BankingConciliation.Domain.Contracts.Services;
using BankingConciliation.Domain.Entities;
using System;

namespace BankingConciliation.Domain.Services
{
    public class TransactionDomainService
        : BaseDomainService<Transaction, Guid>, ITransactionDomainService
    {
        private readonly ITransactionRepository _repository;

        public TransactionDomainService(ITransactionRepository repository)
            : base(repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}
