using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.DTO;
using MyBI.Domain1.DTO.InterfacesDTO;
using MyBI.Domain1.Entities;

namespace TeleHelp.Application.Interface
{
    public interface IGrupoApplication : IAplicationBase<Grupo>
    {
        void UpdaGrupo(Grupo _grupo);
        bool AddGrupoTela(IGrupoDTO grupoDTO);
    }
}
