using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.DTO.InterfacesDTO
{
    public interface ICargoDTO
    {
      
        int IdCargo { get; set; }


        string Nome { get; set; }


        string Descricao { get; set; }

        bool Ativo { get; set; }

        Cargo GetCargo();
        List<Cargo> listaCargos { get; set; }
    }
}
