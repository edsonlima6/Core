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

        public void Add(TEntity obj)
        {
            _servicebase.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _servicebase.Delete(obj);
        }

        public void Dispose()
        {
            _servicebase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _servicebase.GetAll().ToList();
        }

        public TEntity GetById(int? id)
        {
           return _servicebase.GetById(id);
        }

        public void Update(TEntity obj)
        {
            _servicebase.Update(obj);
        }
        public void SaveChanges()
        {
            _servicebase.SaveChanges();
        }
    }

}
