using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class ClientService : ServiceBase<Cliente>, IClientService
    {
        readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository):base(clientRepository)
        {
            _clientRepository = clientRepository;
        }



    }
}
