using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
