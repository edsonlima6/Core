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
    public class DepartamentoApplication : AplicationBase<Departamento>, IDepartamentoAppication
    {
        readonly IDepartamentoService departamentoService;

        public DepartamentoApplication(IDepartamentoService _departamentoService):base(_departamentoService)
        {
            departamentoService = _departamentoService;
        }
    }
}
