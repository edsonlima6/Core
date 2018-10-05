using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class HospitalService : ServiceBase<Hospital>, IHospitalService
    {

        private readonly IHospitalRepository _hospitalRepository;

        public HospitalService(IHospitalRepository hospitalRepository)
            : base(hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

    }
}
