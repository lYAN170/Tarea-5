using MiApp.Models;
using SQLite;

namespace MiApp.Data
{
    public class BaseDatos
    {
        private readonly string _databasePath;
        private SQLiteConnection _connection;

        public BaseDatos(string databasePath)
        {
            _databasePath = databasePath;
            InitializeDatabase();
        }

        // Método para inicializar la base de datos
        private void InitializeDatabase()
        {
            _connection = new SQLiteConnection(_databasePath);
            _connection.CreateTable<Usuario>(); // Crear tabla si no existe
            Console.WriteLine($"Base de datos inicializada en: {_databasePath}");
        }

        // Propiedad para acceder a la conexión
        public SQLiteConnection Connection => _connection;

        // Métodos CRUD (Optimización)
        public Task<Usuario> ObtenerUsuarioAsync(string nombreUsuario, string contrasena)
        {
            return Task.FromResult(_connection.Table<Usuario>()
                        .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena));
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            return Task.FromResult(_connection.Insert(usuario));
        }

        public Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return Task.FromResult(_connection.Table<Usuario>().ToList());
        }

        // Cerrar la conexión cuando sea necesario
        //public void Close() => _connection.Close();
    }
}
