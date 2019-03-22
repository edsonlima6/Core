using MyBI.Domain1.DTO;
using MyBI.Domain1.DTO.InterfacesDTO;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface IGrupoService : IServiceBase<Grupo>
    {
        void UpdateGrupo(Grupo _grupo);
        bool AddGrupoTela(IGrupoDTO grupoDTO);
    }
}
