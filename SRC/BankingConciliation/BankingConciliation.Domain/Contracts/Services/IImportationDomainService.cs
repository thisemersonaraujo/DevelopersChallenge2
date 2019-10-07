using BankingConciliation.Domain.Entities;
using System.Collections.Generic;

namespace BankingConciliation.Domain.Contracts.Services
{
    public interface IImportationDomainService
    {
        List<Transaction> ReadOfxFile(string url);
        List<Transaction> AddTransactionIdentifier(List<Transaction> transactionsList);
    }
}
