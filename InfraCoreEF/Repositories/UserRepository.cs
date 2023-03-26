using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraCoreEF.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InfraCoreEF.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ContextBD contextBD) : base(contextBD) { }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            try
            {
                var users = await Db.Users.AsNoTracking().ToListAsync();
                return users.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            try
            {
                var user = Db.Users.Attach(new User { Id = id });
                user.State = EntityState.Deleted;
                await Db.SaveChangesAsync();

                return (int)TransactionStatus.Committed;

            }
            catch (Exception)
            {
                return (int)TransactionStatus.Aborted;
            }
        }

    }
}
