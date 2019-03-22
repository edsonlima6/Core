using MyBI.Domain1.Entities;

namespace MyBI.Domain1.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ValidaLogin(string login, string senha);
        Usuario AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
    }
}
