using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserHandler 
    {
        Task<int> AddAsync(User entity);
        bool UpdateAsync(int id);

        IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAllAsync();
        void Remove(int id);
    }
}
