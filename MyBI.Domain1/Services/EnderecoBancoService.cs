using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
