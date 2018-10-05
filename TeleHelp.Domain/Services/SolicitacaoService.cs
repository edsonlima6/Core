using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class SolicitacaoService : ServiceBase<Solicitacao>, ISolicitacaoService
    {

        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository)
            : base(solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

    }
}
