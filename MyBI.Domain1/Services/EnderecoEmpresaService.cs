using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
