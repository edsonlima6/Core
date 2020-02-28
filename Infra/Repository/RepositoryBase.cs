using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBI.Domain1.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ContextDB Db = new ContextDB();

        public async Task Add(TEntity obj)
        {
            try
            {
                await Db.Set<TEntity>().AddAsync(obj);
                SaveChanges();
            }
            catch (DbUpdateException erroDbUpdateException)
            {
                Delete(obj);
                throw erroDbUpdateException;
            }
            catch (Exception exAdd)
            {
                Delete(obj);
                throw exAdd;
            }
        }

        public void Delete(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Db.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public TEntity GetById(int? id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateException erroDbUpdateException)
            {
                throw erroDbUpdateException;
            }
            catch (Exception erroException)
            {
                throw erroException;
            }
        }


        public void Update(TEntity obj)
        {
            try
            {
                Db.Entry(obj).State = EntityState.Modified;
            }
            catch (DbUpdateException erroDbUpdateException)
            {
                throw erroDbUpdateException;
            }
            catch (Exception ex)
            {
                Delete(obj);
                throw ex;
            }
        }




    }
}
