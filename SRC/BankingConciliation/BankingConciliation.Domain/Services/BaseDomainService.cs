using BankingConciliation.Domain.Contracts.Repositories;
using BankingConciliation.Domain.Contracts.Services;
using System;
using System.Collections.Generic;

namespace BankingConciliation.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey>
        : IBaseDomainService<TEntity, TKey>
            where TEntity : class
            where TKey : struct
    {
        private readonly IBaseRepository<TEntity, TKey> _repository;

        public BaseDomainService(IBaseRepository<TEntity, TKey> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public void Insert(TEntity obj)
        {
            _repository.BeginTransaction();
            _repository.Insert(obj);
            _repository.Commit();
        }

        public void Update(TEntity obj)
        {
            _repository.BeginTransaction();
            _repository.Update(obj);
            _repository.Commit();
        }

        public void Delete(TEntity obj)
        {
            _repository.BeginTransaction();
            _repository.Delete(obj);
            _repository.Commit();
        }

        public List<TEntity> GetAll()
        {
            return _repository.FindAll();
        }

        public TEntity GetById(TKey id)
        {
            return _repository.FindById(id);
        }


        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
