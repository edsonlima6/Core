using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.DTO.InterfacesDTO
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
