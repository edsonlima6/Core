using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class UnidadeService : ServiceBase<Unidade>, IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
            : base(unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

    }
}
