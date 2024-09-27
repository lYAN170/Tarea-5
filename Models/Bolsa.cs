using SQLite;

namespace MiApp.Models
{
    public class Bolsa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int UsuarioId { get; set; }
        [NotNull]
        public int Cantidad { get; set; }
        [NotNull]
        public double MontoTotal { get; set; }
        [Ignore]
        public List<BolsaProducto> Productos { get; set; }
    }
}
