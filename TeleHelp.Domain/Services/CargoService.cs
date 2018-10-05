using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {

        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
            : base(cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public void UpdateCargo(Cargo cargo)
        {
            var cargoDB = _cargoRepository.GetById(cargo.IdCargo);
            cargoDB.Ativo = cargo.Ativo;
            cargoDB.Nome = cargo.Nome;
            cargoDB.Descricao = cargo.Descricao;
            _cargoRepository.Update(cargoDB);

        }
    }
}
