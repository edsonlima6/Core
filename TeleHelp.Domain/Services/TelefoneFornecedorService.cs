using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
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
