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
    public class TipoEmpresaService : ServiceBase<TipoEmpresa>, ITipoEmpresaService
    {
        private readonly ITipoEmpresaRepository _tipoEmpresaRepository;
        public TipoEmpresaService(ITipoEmpresaRepository tipoEmpresaRepository) : base(tipoEmpresaRepository)
        {
            _tipoEmpresaRepository = tipoEmpresaRepository;
        }
    }
}
