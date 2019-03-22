using System.Collections.Generic;
//using System.Data.Entity;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //System.Data.Common.DbTransaction transaction { get; set; }

        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        void Dispose();
        void SaveChanges();


        //DbContextTransaction BeginTransaction();
        //void CommitTransaction();
        //void RollBackTransaction();
    }
}
