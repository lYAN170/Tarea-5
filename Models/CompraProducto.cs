using SQLite;
namespace MiApp.Models
{
    public class CompraProducto
    {
        [NotNull]
        public int CompraId { get; set; }

        [NotNull]
        public int ProductoId { get; set; }

        [NotNull]
        public int Cantidad { get; set; }

        [NotNull]
        public double PrecioUnitario { get; set; }

        [PrimaryKey]
        public int Id => CompraId + ProductoId;
    }
}
