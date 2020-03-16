using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class AplicationBase<TEntity> : IAplicationBase<TEntity> where TEntity : class
    {
        protected readonly IServiceBase<TEntity> _servicebase;

        public AplicationBase(IServiceBase<TEntity> _Servicebase)
        {
            _servicebase = _Servicebase;
        }

        public async Task Add(TEntity obj)
        {
            try
            {
               await _servicebase.Add(obj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                _servicebase.Delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void Dispose()
        {
            _servicebase.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try 
            {
                return await _servicebase.GetAllAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TEntity GetById(int? id)
        {
            try
            {
                return _servicebase.GetById(id);
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
                return await _servicebase.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _servicebase.Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveChanges()
        {
            try
            {
                _servicebase.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
