using SQLite;

namespace MiApp.Models
{
    public class DetallePago
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, Unique]
        public string NumeroTarjeta { get; set; }
        [NotNull]
        public string FechaVencimiento { get; set; }
        [NotNull]
        public string CodigoCVV { get; set; }
        [NotNull]
        public string NombreTitular { get; set; }
        [NotNull, Unique]
        public String email { get; set; }
    }
}
