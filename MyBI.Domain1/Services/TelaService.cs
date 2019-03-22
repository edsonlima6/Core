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
    public class TelaService : ServiceBase<Tela>, ITelaService
    {
        readonly ITelaRepository telaRepository;
        public TelaService(ITelaRepository _telaRepository):base(_telaRepository)
        {
            telaRepository = _telaRepository;
        }
    }
}
