using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
