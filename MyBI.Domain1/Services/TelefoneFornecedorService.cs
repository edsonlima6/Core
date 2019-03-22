using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class TelefoneFornecedorService : ServiceBase<TelefoneFornecedor>, ITelefoneFornecedorService
    {

        private readonly ITelefoneFornecedorRepository _telefoneFornecedorRepository;

        public TelefoneFornecedorService(ITelefoneFornecedorRepository telefoneFornecedorRepository)
            : base(telefoneFornecedorRepository)
        {
            _telefoneFornecedorRepository = telefoneFornecedorRepository;
        }

    }
}
