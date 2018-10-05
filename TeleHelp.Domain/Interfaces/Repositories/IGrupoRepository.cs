using System.Collections.Generic;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Repositories
{
    public interface IGrupoRepository : IRepositoryBase<Grupo>
    {
        void UpdateGrupo(Grupo _grupo);
    }



}
