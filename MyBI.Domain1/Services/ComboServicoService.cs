using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
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
