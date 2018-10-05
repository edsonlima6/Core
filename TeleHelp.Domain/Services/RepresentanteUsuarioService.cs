using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
