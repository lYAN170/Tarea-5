using MiApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Services
{
    public class OrdenService
    {
        private readonly SQLiteAsyncConnection _database;

        public OrdenService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Orden>().Wait();
        }

        public Task<List<Orden>> GetAll() => _database.Table<Orden>().ToListAsync();

        public Task<Orden> GetOrden(int id) => _database.Table<Orden>().FirstOrDefaultAsync(o => o.Id == id);

        public Task<int> Add(Orden orden) => _database.InsertAsync(orden);

        public Task<int> Update(Orden orden) => _database.UpdateAsync(orden);

        public Task<int> Delete(int id) => _database.DeleteAsync<Orden>(id);
    }
}
