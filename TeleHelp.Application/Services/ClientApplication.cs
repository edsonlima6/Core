using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class ClientApplication : AplicationBase<Cliente>
    {
        readonly IClientService _clientService;
        public ClientApplication(IClientService clientService) : base(clientService)
        {
            _clientService = clientService;

        }
    }
}
