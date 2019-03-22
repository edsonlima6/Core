using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class GrupoTelaService : ServiceBase<PermissaoTela>, IGrupoTelaService
    {
        readonly IGrupoTelaRepository grupoTelaRepository;
        public GrupoTelaService(IGrupoTelaRepository _grupoTelaRepository) :base(_grupoTelaRepository)
        {
            grupoTelaRepository = _grupoTelaRepository;
        }   
    }
}
