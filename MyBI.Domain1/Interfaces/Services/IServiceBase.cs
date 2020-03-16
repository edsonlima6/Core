using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int? id);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();
    }
}
