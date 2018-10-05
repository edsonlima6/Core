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
    public class GrupoUsuarioApplication : AplicationBase<GrupoUsuario>, IGrupoUsuarioApplication
    {
        readonly IGrupoUsuarioService _grupoUsuarioService; 
        public GrupoUsuarioApplication(IGrupoUsuarioService grupoUsuarioService) : base(grupoUsuarioService)
        {
            _grupoUsuarioService = grupoUsuarioService;
        }
    }
}
