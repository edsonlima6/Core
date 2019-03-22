using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class AcaoService : ServiceBase<Acao>, IAcaoService
    {
        private readonly IAcaoRepository _acaoRepository;
        public AcaoService(IAcaoRepository acaoRepository)
            : base(acaoRepository)
        {
            _acaoRepository = acaoRepository;
        }

    }
}
