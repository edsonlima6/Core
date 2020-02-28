using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //System.Data.Common.DbTransaction transaction { get; set; }

        Task Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();


        //DbContextTransaction BeginTransaction();
        //void CommitTransaction();
        //void RollBackTransaction();
    }
}
