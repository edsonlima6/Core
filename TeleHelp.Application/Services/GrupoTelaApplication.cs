using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class GrupoTelaApplication : AplicationBase<PermissaoTela>, IGrupoTelaApplication
    {
        readonly IGrupoTelaService grupoTelaRepository;
        public GrupoTelaApplication(IGrupoTelaService _grupoTelaRepository):base(_grupoTelaRepository)
        {
            grupoTelaRepository = _grupoTelaRepository;
        }
    }
}
