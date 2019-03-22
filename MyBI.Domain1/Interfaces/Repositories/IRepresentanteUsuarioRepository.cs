using System.Collections.Generic;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IRepresentanteUsuarioRepository : IRepositoryBase<RepresentanteUsuario>
    {
        IList<RepresentanteUsuario> GetRepresentanteUsuario(int usuarioID);
    }
}
