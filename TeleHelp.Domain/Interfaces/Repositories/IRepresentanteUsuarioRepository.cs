using System.Collections.Generic;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Repositories
{
    public interface IRepresentanteUsuarioRepository : IRepositoryBase<RepresentanteUsuario>
    {
        IList<RepresentanteUsuario> GetRepresentanteUsuario(int usuarioID);
    }
}
