using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBaseEF<User>
    {
        Task<IQueryable<User>> GetAllAsync();
        Task<int> RemoveAsync(int id);
    }
}
