using SQLite;

namespace MiApp.Models
{
    public class BolsaProducto
    {
        [NotNull]
        public int BolsaId { get; set; }
        [NotNull]
        public int ProductoId { get; set; }
        [NotNull]
        public int Cantidad { get; set; }

        [PrimaryKey]
        public int Id => BolsaId + ProductoId;
    }
}
