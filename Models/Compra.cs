using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MiApp.Models
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TipoEntrega { get; set; }
        [NotNull]
        public DateTime FechaEntrega { get; set; }
        [NotNull]
        public double PrecioTotal { get; set; }
        [NotNull]
        public int TiendaId { get; set; }
        [NotNull]
        public int DespachoId { get; set; }
        [NotNull]
        public int DetallePagoId { get; set; }
        [Ignore]
        public List<CompraProducto> Productos { get; set; }
    }
}


