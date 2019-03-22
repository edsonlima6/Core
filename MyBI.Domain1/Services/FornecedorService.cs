using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
            : base(fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

    }
}
