using System.Collections.Generic;
using MyBI.Domain1.DTO.InterfacesDTO;
using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ValidaLogin(string login, string senha);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
    }
}
