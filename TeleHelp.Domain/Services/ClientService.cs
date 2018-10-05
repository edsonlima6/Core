using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
