using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {

        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
            : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

    }
}
