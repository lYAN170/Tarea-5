using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarritoApp.Models;
using CarritoApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Controllers
{
    public class ProveedorController
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController(string dbPath)
        {
            _proveedorService = new ProveedorService(dbPath);
        }

        public Task<List<Proveedor>> GetAllProveedores() => _proveedorService.GetAll();
        public Task AddProveedor(Proveedor proveedor) => _proveedorService.Add(proveedor);
        public Task UpdateProveedor(Proveedor proveedor) => _proveedorService.Update(proveedor);
        public Task DeleteProveedor(int id) => _proveedorService.Delete(id);
    }
}

