using SQLite;

namespace MiApp.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string NombreUsuario { get; set; }

        [MaxLength(100)]
        public string Contrasena { get; set; }
    }

}
