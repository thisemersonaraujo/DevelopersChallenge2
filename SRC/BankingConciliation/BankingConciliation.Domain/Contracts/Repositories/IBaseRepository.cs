using System.Collections.Generic;

namespace BankingConciliation.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> FindAll();
        TEntity FindById(TKey id);

        void BeginTransaction();
        void Commit();
        void Rollback();

        void Dispose();
    }
}
