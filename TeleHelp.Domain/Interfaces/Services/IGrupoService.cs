using TeleHelp.Domain.DTO;
using TeleHelp.Domain.DTO.InterfacesDTO;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Services
{
    public interface IGrupoService : IServiceBase<Grupo>
    {
        void UpdateGrupo(Grupo _grupo);
        bool AddGrupoTela(IGrupoDTO grupoDTO);
    }
}
