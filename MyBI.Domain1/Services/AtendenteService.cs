using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class AtendenteService : ServiceBase<Atendente>, IAtendenteService
    {

        private readonly IAtendenteRepository _atendenteRepository;

        public AtendenteService(IAtendenteRepository atendenteRepository)
            : base(atendenteRepository)
        {
            _atendenteRepository = atendenteRepository;
        }
    }
}
