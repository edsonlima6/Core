using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
