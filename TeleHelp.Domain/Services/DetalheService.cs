using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class DetalheService : ServiceBase<Detalhe>, IDetalheService
    {

        private readonly IDetalheRepository _detalheRepository;

        public DetalheService(IDetalheRepository detalheRepository)
            : base(detalheRepository)
        {
            _detalheRepository = detalheRepository;
        }

    }
}
