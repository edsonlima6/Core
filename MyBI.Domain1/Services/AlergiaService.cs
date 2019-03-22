using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class AlergiaService : ServiceBase<Alergia>, IAlergiaService
    {
        private readonly IAlergiaRepository _alergiaRepository;

        public AlergiaService(IAlergiaRepository alergiaRepository)
            : base(alergiaRepository)
        {
            _alergiaRepository = alergiaRepository;
        }

    }
}
