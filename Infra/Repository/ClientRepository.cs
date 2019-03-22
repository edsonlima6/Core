using System;
using System.Collections.Generic;
using System.Text;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;

namespace Infra.Repository
{
    public class ClientRepository : RepositoryBase<Cliente>, IClientRepository
    {

        public ClientRepository()
        {

        }



    }
}
