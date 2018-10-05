using System;
using System.Collections.Generic;
using System.Text;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;

namespace Infra.Repository
{
    public class ClientRepository : RepositoryBase<Cliente>, IClientRepository
    {

        public ClientRepository()
        {

        }



    }
}
