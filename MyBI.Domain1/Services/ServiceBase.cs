using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task Add(TEntity obj)
        {
            try
            {
                await _repository.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public TEntity GetById(int? id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           try
           {
               return await _repository.GetAllAsync();
           }
           catch(Exception ex)
           {
               throw ex;
           }
            
        }

        public void Update(TEntity obj)
        {
            try
            {
                _repository.Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void Delete(TEntity obj)
        {
            try
            {
                _repository.Delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
