using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class FeriadoService : ServiceBase<Feriado>, IFeriadoService
    {

        private readonly IFeriadoRepository _feriadoRepository;

        public FeriadoService(IFeriadoRepository feriadoRepository)
            : base(feriadoRepository)
        {
            _feriadoRepository = feriadoRepository;
        }

    }
}
