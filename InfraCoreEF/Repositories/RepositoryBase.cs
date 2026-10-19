using Domain.Interfaces.Repositories;
using InfraCoreEF.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InfraCoreEF.Repositories
{
    public class RepositoryBase<T> : IRepositoryBaseEF<T> where T : class
    {
        protected ContextBD Db { get; set; }
        protected DbSet<T> dbSet { get; set; }
        public RepositoryBase(ContextBD contextBD)
        {
            Db = contextBD;
            dbSet = Db.Set<T>();
        }

        public async Task InsertAsync(T obj)
        {
            try
            {
                await Db.AddAsync(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<long> Update()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetById()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual Task<long> Delete(T user)
        {
            dbSet.Remove(user);
            return Task.FromResult(long.MinValue);
        }

        public void SaveChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Async version for consistency with async flows
        public async Task SaveChangesAsync()
        {
            try
            {
                await Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        // Keep compatibility but prefer using UnitOfWork/DbContext transaction APIs.
        public IDbConnection GetTransaction()
        {
            return Db.Database.GetDbConnection();
        }
    }
}
