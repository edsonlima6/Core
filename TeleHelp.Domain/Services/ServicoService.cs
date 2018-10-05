using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {

        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
            : base(servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

    }
}
