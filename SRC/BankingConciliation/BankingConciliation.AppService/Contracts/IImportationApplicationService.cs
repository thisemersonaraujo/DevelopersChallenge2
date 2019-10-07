using BankingConciliation.Domain.Entities;
using System.Collections.Generic;

namespace BankingConciliation.AppService.Contracts
{
    public interface IImportationApplicationService
    {
        List<Transaction> ReadOfxFile(string url);
        List<Transaction> AddTransactionIdentifier(List<Transaction> transactionsList);
    }
}
