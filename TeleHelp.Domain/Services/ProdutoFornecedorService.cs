using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ProdutoFornecedorService : ServiceBase<ProdutoFornecedor>, IProdutoFornecedorService
    {

        private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;

        public ProdutoFornecedorService(IProdutoFornecedorRepository produtoFornecedorRepository)
            : base(produtoFornecedorRepository)
        {
            _produtoFornecedorRepository = produtoFornecedorRepository;
        }

    }
}
