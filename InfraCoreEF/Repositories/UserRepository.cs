using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraCoreEF.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
