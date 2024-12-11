using MiApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Repositories 
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public OrdenRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Orden>().Wait(); 
        }

        public Task<List<Orden>> GetAll()
        {
            return _database.Table<Orden>().ToListAsync();
        }

        public Task<int> Add(Orden orden)
        {
            return _database.InsertAsync(orden);
        }

        public Task<int> Update(Orden orden)
        {
            return _database.UpdateAsync(orden);
        }

        public Task<int> Delete(int id)
        {
            return _database.DeleteAsync<Orden>(id);
        }
    }
}
