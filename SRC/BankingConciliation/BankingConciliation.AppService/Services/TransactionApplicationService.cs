using BankingConciliation.AppService.Contracts;
using BankingConciliation.AppService.Useful;
using BankingConciliation.Domain.Contracts.Services;
using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingConciliation.AppService.Services
{
    public class TransactionApplicationService
        : BaseApplicationService<Transaction, Guid>, ITransactionApplicationService
    {
        private readonly ITransactionDomainService _domain;

        public TransactionApplicationService(ITransactionDomainService domain)
            : base(domain)
        {
            _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        }

        public void SaveList(List<Transaction> transactionsList)
        {
            try
            {
                Cryptography criptografy = new Cryptography();
                var newTransactionList = RemoveDuplicity(transactionsList);

                foreach (var transaction in newTransactionList.ToList())
                {
                    _domain.Insert(transaction);
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private List<Transaction> RemoveDuplicity(List<Transaction> transactions)
        {
            var identifiers = transactions.Select(s => s.Identifier).ToList();
            var identifiersBd = _domain.GetAll().Where(c => identifiers.Contains(c.Identifier)).Select(s => s.Identifier).ToList();

            return transactions.Where(t => !identifiersBd.Contains(t.Identifier)).ToList() ?? new List<Transaction>();
        }
    }
}
