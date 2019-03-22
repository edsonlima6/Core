using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class RepresentanteUsuarioService : ServiceBase<RepresentanteUsuario>, IRepresentanteUsuarioService
    {

        private readonly IRepresentanteUsuarioRepository _representanteUsuarioRepository;

        public RepresentanteUsuarioService(IRepresentanteUsuarioRepository representanteUsuarioRepository)
            : base(representanteUsuarioRepository)
        {
            _representanteUsuarioRepository = representanteUsuarioRepository;
        }

    }
}
