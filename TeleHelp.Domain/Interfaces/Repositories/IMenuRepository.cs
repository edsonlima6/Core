
using System.Collections.Generic;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Repositories
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {
        IEnumerable<Menu> BuscaPorUsuario(int IdUsuario);
    }
}
