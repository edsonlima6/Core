using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleHelp.Application.Interface
{
    public interface IAplicationBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();
    }
}
