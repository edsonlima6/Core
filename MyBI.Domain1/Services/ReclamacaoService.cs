using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
