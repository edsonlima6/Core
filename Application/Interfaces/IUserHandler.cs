using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserHandler
    {
        Task<int> AddAsync(CreateUserDto entity);
        bool UpdateAsync(int id);

        IEnumerable<UserDto> GetAll();
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<int> RemoveAsync(int id);
    }
}
