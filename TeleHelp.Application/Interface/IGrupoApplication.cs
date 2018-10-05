using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.DTO;
using TeleHelp.Domain.DTO.InterfacesDTO;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Application.Interface
{
    public interface IGrupoApplication : IAplicationBase<Grupo>
    {
        void UpdaGrupo(Grupo _grupo);
        bool AddGrupoTela(IGrupoDTO grupoDTO);
    }
}
