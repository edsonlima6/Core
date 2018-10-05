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
    public class GrupoTelaService : ServiceBase<PermissaoTela>, IGrupoTelaService
    {
        readonly IGrupoTelaRepository grupoTelaRepository;
        public GrupoTelaService(IGrupoTelaRepository _grupoTelaRepository) :base(_grupoTelaRepository)
        {
            grupoTelaRepository = _grupoTelaRepository;
        }   
    }
}
