using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
