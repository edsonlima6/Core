using System.Collections.Generic;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IGrupoRepository : IRepositoryBase<Grupo>
    {
        void UpdateGrupo(Grupo _grupo);
    }



}
