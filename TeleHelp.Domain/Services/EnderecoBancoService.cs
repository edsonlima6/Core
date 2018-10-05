using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class EnderecoBancoService : ServiceBase<EnderecoBanco>, IEnderecoBancoService
    {

        private readonly IEnderecoBancoRepository _enderecoBancoRepository;

        public EnderecoBancoService(IEnderecoBancoRepository enderecoBancoRepository)
            : base(enderecoBancoRepository)
        {
            _enderecoBancoRepository = enderecoBancoRepository;
        }

    }
}
