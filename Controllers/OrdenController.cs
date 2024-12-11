using MiApp.Models;
using MiApp.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MiApp.Controller
{
    public class OrdenController
    {
        private readonly OrdenService _ordenService;

        
        public OrdenController(string dbPath)
        {
            _ordenService = new OrdenService(dbPath);
        }

        public Task<List<Orden>> GetAllOrdenes() => _ordenService.GetAll();

        public Task AddOrden(Orden orden) => _ordenService.Add(orden);

        public Task UpdateOrden(Orden orden) => _ordenService.Update(orden);

        public Task DeleteOrden(int id) => _ordenService.Delete(id);

        public Task<Orden> GetOrden(int id) => _ordenService.GetOrden(id);
    }
}
