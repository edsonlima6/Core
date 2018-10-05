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
    public class RepresentanteUsuarioApplcation : AplicationBase<RepresentanteUsuario>, IRepresentanteUsuarioApplication
    {
        readonly IRepresentanteUsuarioService _representanteUsuarioService;
        public RepresentanteUsuarioApplcation(IRepresentanteUsuarioService representanteUsuarioService) : base(representanteUsuarioService)
        {
            _representanteUsuarioService = representanteUsuarioService;
        }
    }
}
