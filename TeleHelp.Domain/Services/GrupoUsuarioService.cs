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
    public class GrupoUsuarioService : ServiceBase<GrupoUsuario>, IGrupoUsuarioService
    {
        readonly IGrupoUsuarioRepository _grupoUsuarioRepository;
        public GrupoUsuarioService(IGrupoUsuarioRepository grupoUsuarioRepository) : base(grupoUsuarioRepository)
        {
            _grupoUsuarioRepository = grupoUsuarioRepository;
        }

    }
}
