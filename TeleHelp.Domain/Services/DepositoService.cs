using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class DepositoService : ServiceBase<Deposito>, IDepositoService
    {

        private readonly IDepositoRepository _depositoRepository;

        public DepositoService(IDepositoRepository depositoRepository)
            : base(depositoRepository)
        {
            _depositoRepository = depositoRepository;
        }

    }
}
