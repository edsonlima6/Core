using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
