using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class AssistenciaMedicaService : ServiceBase<AssistenciaMedica>, IAssistenciaMedicaService
    {

        private readonly IAssistenciaMedicaRepository _assistenciaMedicaRepository;

        public AssistenciaMedicaService(IAssistenciaMedicaRepository assistenciaMedicaRepository)
            : base(assistenciaMedicaRepository)
        {
            _assistenciaMedicaRepository = assistenciaMedicaRepository;
        }

    }
}
