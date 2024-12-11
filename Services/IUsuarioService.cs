using MiApp.Models;

namespace MiApp.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioAsync(string nombreUsuario);
        Task<bool> RegistrarUsuarioAsync(string nombreUsuario, string contrasena);
        Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contrasena);
    }
}