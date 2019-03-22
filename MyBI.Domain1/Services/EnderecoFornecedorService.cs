using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class EnderecoFornecedorService : ServiceBase<EnderecoFornecedor>, IEnderecoFornecedorService
    {

        private readonly IEnderecoFornecedorRepository _enderecoFornecedorRepository;

        public EnderecoFornecedorService(IEnderecoFornecedorRepository enderecoFornecedorRepository)
            : base(enderecoFornecedorRepository)
        {
            _enderecoFornecedorRepository = enderecoFornecedorRepository;
        }

    }
}
