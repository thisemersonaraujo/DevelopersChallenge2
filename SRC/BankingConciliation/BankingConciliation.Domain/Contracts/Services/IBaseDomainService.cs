using System.Collections.Generic;

namespace BankingConciliation.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        List<TEntity> GetAll();

        TEntity GetById(TKey id);

        void Dispose();
    }
}
