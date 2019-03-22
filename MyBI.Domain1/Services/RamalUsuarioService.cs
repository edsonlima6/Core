using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
