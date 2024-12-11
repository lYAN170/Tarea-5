using CarritoApp.Models;
using MiApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Services
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();
            _database.CreateTableAsync<Departamento>().Wait();
            _database.CreateTableAsync<Tienda>().Wait();
            _database.CreateTableAsync<Proveedor>().Wait();
            _database.CreateTableAsync<Orden>().Wait();      // Nueva tabla de órdenes


        }


        public Task<List<Producto>> GetAllProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<Producto> GetProductoAsync(int id) => _database.Table<Producto>().FirstOrDefaultAsync(p => p.Id == id);
        public Task<int> SaveProductoAsync(Producto producto) => producto.Id != 0 ? _database.UpdateAsync(producto) : _database.InsertAsync(producto);
        public Task<int> DeleteProductoAsync(int id) => _database.DeleteAsync<Producto>(id);


        public Task<List<Categoria>> GetAllCategoriasAsync() => _database.Table<Categoria>().ToListAsync();
        public Task<int> SaveCategoriaAsync(Categoria categoria) => categoria.Id != 0 ? _database.UpdateAsync(categoria) : _database.InsertAsync(categoria);
        public Task<int> DeleteCategoriaAsync(int id) => _database.DeleteAsync<Categoria>(id);

        public Task<List<Departamento>> GetAllDepartamentosAsync() => _database.Table<Departamento>().ToListAsync();
        public Task<int> SaveDepartamentoAsync(Departamento departamento) =>
            departamento.Id != 0 ? _database.UpdateAsync(departamento) : _database.InsertAsync(departamento);
        public Task<int> DeleteDepartamentoAsync(int id) => _database.DeleteAsync<Departamento>(id);

        public Task<List<Tienda>> GetAllTiendasAsync() => _database.Table<Tienda>().ToListAsync();

        public Task<Tienda> GetTiendaAsync(int id) => _database.Table<Tienda>().FirstOrDefaultAsync(t => t.Id == id);

        public Task<int> SaveTiendaAsync(Tienda tienda) => tienda.Id != 0 ? _database.UpdateAsync(tienda) : _database.InsertAsync(tienda);

        public Task<int> DeleteTiendaAsync(int id) => _database.DeleteAsync<Tienda>(id);


        public Task<List<Proveedor>> GetAllProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();
        public Task<int> SaveProveedorAsync(Proveedor proveedor) => proveedor.Id != 0 ? _database.UpdateAsync(proveedor) : _database.InsertAsync(proveedor);
        public Task<int> DeleteProveedorAsync(int id) => _database.DeleteAsync<Proveedor>(id);



        // Métodos para órdenes
        public Task<List<Orden>> GetAllOrdenesAsync() => _database.Table<Orden>().ToListAsync();
        public Task<int> SaveOrdenAsync(Orden orden) => orden.Id != 0 ? _database.UpdateAsync(orden) : _database.InsertAsync(orden);
        public Task<int> DeleteOrdenAsync(int id) => _database.DeleteAsync<Orden>(id);



    }
}
