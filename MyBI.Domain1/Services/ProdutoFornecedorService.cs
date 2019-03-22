using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
