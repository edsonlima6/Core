using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
