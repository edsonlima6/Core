using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
