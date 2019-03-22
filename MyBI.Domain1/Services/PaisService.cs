using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class PaisService : ServiceBase<Pais>, IPaisService
    {

        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
            : base(paisRepository)
        {
            _paisRepository = paisRepository;
        }

    }
}
