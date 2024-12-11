using MiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Services
{
    public interface ITiendaService
    {
        Task<List<Tienda>> GetAllTiendas();
        Task AddTienda(Tienda tienda);
    }
}
