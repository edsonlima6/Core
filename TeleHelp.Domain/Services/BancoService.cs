using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class BancoService : ServiceBase<Banco>, IBancoService
    {

        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository)
            : base(bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

    }
}
