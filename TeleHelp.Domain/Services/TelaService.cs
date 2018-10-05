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
    public class TelaService : ServiceBase<Tela>, ITelaService
    {
        readonly ITelaRepository telaRepository;
        public TelaService(ITelaRepository _telaRepository):base(_telaRepository)
        {
            telaRepository = _telaRepository;
        }
    }
}
