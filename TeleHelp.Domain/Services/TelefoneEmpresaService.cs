using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
