using TeleHelp.Domain.Entities;
using TeleHelp.Domain.Interfaces.Repositories;
using TeleHelp.Domain.Interfaces.Services;

namespace TeleHelp.Domain.Services
{
    public class ComboService : ServiceBase<Combo>, IComboService
    {

        private readonly IComboRepository _comboRepository;

        public ComboService(IComboRepository comboRepository)
            : base(comboRepository)
        {
            _comboRepository = comboRepository;
        }

    }
}
