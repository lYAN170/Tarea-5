
using SQLite;

namespace MiApp.Models
{
    public class Despacho
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int PersonaContacto { get; set; }
        [NotNull]
        public string Direccion { get; set; }
        [NotNull]
        public string Celular { get; set; }
        [NotNull]
        public int DepartamentoId { get; set; }
        [NotNull]
        public int ProvinciaId { get; set; }
        [NotNull]
        public int DistritoId { get; set; }
    }
}
