using MiApp.Models;
using MiApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Controllers
{
    public class TiendaController
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaController(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public Task<List<Tienda>> GetAllTiendas() => _tiendaRepository.GetAll();

        public Task AddTienda(Tienda tienda) => _tiendaRepository.Add(tienda);
    }
}
