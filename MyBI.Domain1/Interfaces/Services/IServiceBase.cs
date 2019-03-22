using System.Collections.Generic;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();
    }
}
