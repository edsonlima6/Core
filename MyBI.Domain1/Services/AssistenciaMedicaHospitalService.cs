using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
