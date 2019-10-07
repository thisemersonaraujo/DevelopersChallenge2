using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConciliation.AppService.Contracts
{
    public interface IBaseApplicationService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        List<TEntity> GetAll();

        TEntity GetById(TKey key);

        void Dispose();
    }
}
