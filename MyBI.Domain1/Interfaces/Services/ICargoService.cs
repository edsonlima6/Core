using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface ICargoService : IServiceBase<Cargo>
    {
        void UpdateCargo(Cargo cargo);
    }
}
