using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class TipoEmpresaApplication : AplicationBase<TipoEmpresa>, ITipoEmpresaApplication
    {
        private readonly ITipoEmpresaService _tipoEmpresaService;
        public TipoEmpresaApplication(ITipoEmpresaService tipoEmpresaService) : base(tipoEmpresaService)
        {
            _tipoEmpresaService = tipoEmpresaService;
        }
    }
}
