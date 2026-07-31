using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Handles
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository repositoryBaseEF;

        public UserHandler(IUserRepository repositoryBaseEF)
        {
            this.repositoryBaseEF = repositoryBaseEF;
        }

        public async Task<int> AddAsync(CreateUserDto dto)
        {
            var user = new User(dto.Name, dto.Email, dto.LastName)
            {
                CreatedON = DateTime.Now,
                Password = dto.Password
            };

            var validation = user.IsValid();
            if (!validation.valid)
                throw new ArgumentException(validation.message);

            await repositoryBaseEF.InsertAsync(user);
            repositoryBaseEF.SaveChanges();

            return user.Id;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return repositoryBaseEF.GetAll().Select(MapToDto);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await repositoryBaseEF.GetAllAsync();
            return users.Select(MapToDto);
        }

        public async Task<int> RemoveAsync(int id) => await repositoryBaseEF.RemoveAsync(id);

        public bool UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                GuidId = user.GuidId,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
