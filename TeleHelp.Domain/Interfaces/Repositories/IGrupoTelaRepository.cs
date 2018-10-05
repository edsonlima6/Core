using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Repositories
{
    public interface IGrupoTelaRepository : IRepositoryBase<PermissaoTela>
    {
        IList<PermissaoTela> GetTelasHabilitadas(int IdGrupo);
    }
}
