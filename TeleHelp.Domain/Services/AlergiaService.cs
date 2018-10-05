using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
