using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Repositories
{
    public interface IGrupoUsuarioRepository : IRepositoryBase<GrupoUsuario>
    {
        IList<GrupoUsuario> GetGrupoUsuario(int usuarioID);
    }
}
