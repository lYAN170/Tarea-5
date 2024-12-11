using MiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Repositories
{
    public interface ITiendaRepository
    {
        Task<List<Tienda>> GetAll();
        Task Add(Tienda tienda);
    }
}
