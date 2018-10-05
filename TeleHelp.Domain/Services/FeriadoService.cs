using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class FeriadoService : ServiceBase<Feriado>, IFeriadoService
    {

        private readonly IFeriadoRepository _feriadoRepository;

        public FeriadoService(IFeriadoRepository feriadoRepository)
            : base(feriadoRepository)
        {
            _feriadoRepository = feriadoRepository;
        }

    }
}
