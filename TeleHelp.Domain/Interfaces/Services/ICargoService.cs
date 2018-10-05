using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Services
{
    public interface ICargoService : IServiceBase<Cargo>
    {
        void UpdateCargo(Cargo cargo);
    }
}
