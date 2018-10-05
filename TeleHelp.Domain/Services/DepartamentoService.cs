using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class DepartamentoService : ServiceBase<Departamento>, IDepartamentoService
    {

        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
            : base(departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

    }
}
