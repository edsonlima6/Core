using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
