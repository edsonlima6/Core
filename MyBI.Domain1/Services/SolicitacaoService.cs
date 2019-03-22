using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
