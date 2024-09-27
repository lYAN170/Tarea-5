using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiApp.Models;

namespace MiApp.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioAsync(string nombreUsuario);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<int> AddUsuarioAsync(Usuario usuario);
        Task<int> UpdateUsuarioAsync(Usuario usuario);
        Task<int> DeleteUsuarioAsync(string nombreUsuario);
    }
}
