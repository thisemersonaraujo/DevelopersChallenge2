using BankingConciliation.AppService.Contracts;
using BankingConciliation.Domain.Contracts.Services;
using System;
using System.Collections.Generic;

namespace BankingConciliation.AppService.Services
{
    public abstract class BaseApplicationService<TEntity, TKey>
        : IBaseApplicationService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        // Domain level property
        private readonly IBaseDomainService<TEntity, TKey> _domain;

        public BaseApplicationService(IBaseDomainService<TEntity, TKey> domain)
        {
            _domain = domain ?? throw new ArgumentNullException(nameof(domain));
        }

        //métodos para os serviços da aplicação..
        public void Insert(TEntity obj)
        {
            _domain.Insert(obj);
        }

        public void Update(TEntity obj)
        {
            _domain.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            _domain.Delete(obj);
        }

        public List<TEntity> GetAll()
        {
            return _domain.GetAll();
        }

        public TEntity GetById(TKey key)
        {
            return _domain.GetById(key);
        }

        public void Dispose()
        {
            _domain.Dispose();
        }
    }
}
