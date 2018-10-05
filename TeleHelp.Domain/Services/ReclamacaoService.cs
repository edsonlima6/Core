using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ReclamacaoService : ServiceBase<Reclamacao>, IReclamacaoService
    {

        private readonly IReclamacaoRepository _reclamacaoRepository;

        public ReclamacaoService(IReclamacaoRepository reclamacaoRepository)
            : base(reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

    }
}
