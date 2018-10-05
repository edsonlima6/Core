using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
