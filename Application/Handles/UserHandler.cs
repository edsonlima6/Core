using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handles
{
    public class UserHandler : IUserHandler
    {
        readonly IUserRepository repositoryBaseEF;
        public UserHandler(IUserRepository _repositoryBaseEF)
        {
            repositoryBaseEF = _repositoryBaseEF;
        }
        public async Task<int> AddAsync(User entity)
        {
            try
            {
                await repositoryBaseEF.InsertAsync(entity);
                repositoryBaseEF.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return repositoryBaseEF.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await repositoryBaseEF.GetAllAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> RemoveAsync(int id) => await repositoryBaseEF.RemoveAsync(id);

        public bool UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
