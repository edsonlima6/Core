using System.Collections.Generic;
using TeleHelp.Domain.DTO.InterfacesDTO;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ValidaLogin(string login, string senha);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
    }
}
