using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class CargoApplication : AplicationBase<Cargo>, ICargoApplication
    {
        readonly ICargoService cargoService;

        public CargoApplication(ICargoService _cargoService) : base(_cargoService)
        {
            cargoService = _cargoService;
        }

        public void UpdateCargo(Cargo cargo)
        {
            cargoService.UpdateCargo(cargo);
        }
    }
}
