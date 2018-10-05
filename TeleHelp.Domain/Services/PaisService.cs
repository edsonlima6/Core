using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class PaisService : ServiceBase<Pais>, IPaisService
    {

        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
            : base(paisRepository)
        {
            _paisRepository = paisRepository;
        }

    }
}
