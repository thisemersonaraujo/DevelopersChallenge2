using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BankingConciliation.AppService.Contracts
{
    public interface ITransactionApplicationService
        : IBaseApplicationService<Transaction, Guid>
    {
        void SaveList(List<Transaction> transactionsList);
    }
}
