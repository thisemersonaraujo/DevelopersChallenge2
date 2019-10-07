using BankingConciliation.Domain.Contracts.Repositories;
using BankingConciliation.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BankingConciliation.Infra.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>
        : IBaseRepository<TEntity, TKey>, IDisposable
        where TEntity : class
        where TKey : struct
    {
        protected readonly DataContext _context;

        // Transactions Manager
        private DbContextTransaction _transaction;

        public BaseRepository()
        {
            _context = new DataContext();
        }

        public void Insert(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity FindById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }


        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
