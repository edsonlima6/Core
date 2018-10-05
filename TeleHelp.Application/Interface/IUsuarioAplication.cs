using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHelp.Domain.DTO.InterfacesDTO;
using TeleHelp.Domain.Entities;

namespace TeleHelp.Application.Interface
{
    public interface IUsuarioAplication : IAplicationBase<Usuario>
    {
        Usuario ValidaLogin(string login, string senha);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
    }
}
