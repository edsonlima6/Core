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
        public int AddAsync(User entity)
        {
            try
            {



                return 0;
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

        public bool RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
