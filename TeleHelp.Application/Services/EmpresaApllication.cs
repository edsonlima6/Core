using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class EmpresaApllication : AplicationBase<Empresa>, IEmpresaApplication
    {
        IEmpresaService _empresaService;
        public EmpresaApllication(IEmpresaService empresaApplication) : base(empresaApplication)
        {
            _empresaService = empresaApplication;
        }
    }
}
