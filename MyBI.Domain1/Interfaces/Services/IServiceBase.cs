using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();
    }
}
