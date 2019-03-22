using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class RelatorioService : ServiceBase<Relatorio>, IRelatorioService
    {

        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
            : base(relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

    }
}
