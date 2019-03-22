using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
