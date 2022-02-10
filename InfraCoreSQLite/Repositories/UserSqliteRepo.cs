using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraCoreSQLite.Repositories
{
    public class UserSqliteRepo : IUserRepository
    {
        SQLiteDbContext Db;
        public UserSqliteRepo(SQLiteDbContext _sQLiteDbContext)
        {
            Db = _sQLiteDbContext;
        }

        public Task<long> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<long> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public async void Dispose()
        {
          await  Db.DisposeAsync();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            try
            {
                var users = await Db.Users.AsNoTracking().ToListAsync();
                return users.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetById()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(User obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<long> Update()
        {
            throw new NotImplementedException();
        }
    }
}
