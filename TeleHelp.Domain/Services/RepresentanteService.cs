using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class RepresentanteService : ServiceBase<Representante>, IRepresentanteService
    {

        private readonly IRepresentanteRepository _representanteRepository;

        public RepresentanteService(IRepresentanteRepository representanteRepository)
            : base(representanteRepository)
        {
            _representanteRepository = representanteRepository;
        }

    }
}
