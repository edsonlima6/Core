using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class AssistenciaMedicaHospitalService : ServiceBase<AssistenciaMedicaHospital>, IAssistenciaMedicaHospitalService
    {

        private readonly IAssistenciaMedicaHospitalRepository _assistenciaMedicaHospitalRepository;

        public AssistenciaMedicaHospitalService(IAssistenciaMedicaHospitalRepository assistenciaMedicaHospitalRepository)
            : base(assistenciaMedicaHospitalRepository)
        {
            _assistenciaMedicaHospitalRepository = assistenciaMedicaHospitalRepository;
        }

    }
}
