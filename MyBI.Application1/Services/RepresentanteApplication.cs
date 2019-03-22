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
    public class RepresentanteApplication : AplicationBase<Representante>, IRepresentanteApplication
    {
        readonly IRepresentanteService representanteService;
        public RepresentanteApplication(IRepresentanteService _representanteService):base(_representanteService)
        {
            representanteService = _representanteService;
        }
    }
}
