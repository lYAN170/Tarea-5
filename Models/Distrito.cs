using SQLite;

namespace MiApp.Models
{
    public class Distrito
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ProvinciaId { get; set; }
        [NotNull]
        public string NombreDistrito { get; set; }
    }
}