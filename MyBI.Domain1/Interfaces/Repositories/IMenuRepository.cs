
using System.Collections.Generic;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {
        IEnumerable<Menu> BuscaPorUsuario(int IdUsuario);
    }
}
