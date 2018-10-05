using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class CondicaoService : ServiceBase<Condicao>, ICondicaoService
    {

        private readonly ICondicaoRepository _condicaoRepository;

        public CondicaoService(ICondicaoRepository condicaoRepository)
            : base(condicaoRepository)
        {
            _condicaoRepository = condicaoRepository;
        }

    }
}
