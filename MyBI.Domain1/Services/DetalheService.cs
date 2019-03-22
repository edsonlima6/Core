using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
