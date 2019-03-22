using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
