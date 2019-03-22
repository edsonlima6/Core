using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class TelefoneEmpresaService : ServiceBase<TelefoneEmpresa>, ITelefoneEmpresaService
    {

        private readonly ITelefoneEmpresaRepository _telefoneEmpresaRepository;

        public TelefoneEmpresaService(ITelefoneEmpresaRepository telefoneEmpresaRepository)
            : base(telefoneEmpresaRepository)
        {
            _telefoneEmpresaRepository = telefoneEmpresaRepository;
        }

    }
}
