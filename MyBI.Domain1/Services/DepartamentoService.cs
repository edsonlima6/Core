using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
