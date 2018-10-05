using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ComissaoService : ServiceBase<Comissao>, IComissaoService
    {

        private readonly IComissaoRepository _comissaoRepository;

        public ComissaoService(IComissaoRepository comissaoRepository)
            : base(comissaoRepository)
        {
            _comissaoRepository = comissaoRepository;
        }

    }
}
