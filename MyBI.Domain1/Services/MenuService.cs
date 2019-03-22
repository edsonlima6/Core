using MyBI.Domain1.Entities;
using MyBI.Domain1.Interfaces.Repositories;
using MyBI.Domain1.Interfaces.Services;

namespace MyBI.Domain1.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {

        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
            : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }
    }
}
