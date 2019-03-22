using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
