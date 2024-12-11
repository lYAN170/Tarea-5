using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarritoApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class ProveedorService
    {
        private readonly SQLiteAsyncConnection _connection;

        public ProveedorService(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Proveedor>().Wait();
        }

        public Task<List<Proveedor>> GetAll() => _connection.Table<Proveedor>().ToListAsync();
        public Task<int> Add(Proveedor proveedor) => _connection.InsertAsync(proveedor);
        public Task<int> Update(Proveedor proveedor) => _connection.UpdateAsync(proveedor);
        public Task<int> Delete(int id) => _connection.DeleteAsync<Proveedor>(id);
    }
}


