using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ComboServicoService : ServiceBase<ComboServico>, IComboServicoService
    {

        private readonly IComboServicoRepository _comboServicoRepository;

        public ComboServicoService(IComboServicoRepository comboServicoRepository)
            : base(comboServicoRepository)
        {
            _comboServicoRepository = comboServicoRepository;
        }

    }
}
