using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class EnderecoEmpresaService : ServiceBase<EnderecoEmpresa>, IEnderecoEmpresaService
    {

        private readonly IEnderecoEmpresaRepository _enderecoEmpresaRepository;

        public EnderecoEmpresaService(IEnderecoEmpresaRepository enderecoEmpresaRepository)
            : base(enderecoEmpresaRepository)
        {
            _enderecoEmpresaRepository = enderecoEmpresaRepository;
        }

    }
}
