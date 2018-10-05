using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class RamalUsuarioService : ServiceBase<RamalUsuario>, IRamalUsuarioService
    {

        private readonly IRamalUsuarioRepository _ramalUsuarioRepository;

        public RamalUsuarioService(IRamalUsuarioRepository ramalUsuarioRepository)
            : base(ramalUsuarioRepository)
        {
            _ramalUsuarioRepository = ramalUsuarioRepository;
        }

    }
}
