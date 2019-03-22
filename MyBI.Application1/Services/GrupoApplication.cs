using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Application.Interface;
using MyBI.Domain1.DTO;
using MyBI.Domain1.DTO.InterfacesDTO;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Services;

namespace TeleHelp.Application.Services
{
    public class GrupoApplication : AplicationBase<Grupo>, IGrupoApplication
    {
        readonly IGrupoService _gruposervice;
        public GrupoApplication(IGrupoService gruposervice) : base(gruposervice)
        {
            _gruposervice = gruposervice;
        }

        public bool AddGrupoTela(IGrupoDTO grupoDTO)
        {
            return _gruposervice.AddGrupoTela(grupoDTO);
        }

        public void UpdaGrupo(Grupo _grupo)
        {
            _gruposervice.UpdateGrupo(_grupo);
        }
    }
}
