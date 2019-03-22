using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
