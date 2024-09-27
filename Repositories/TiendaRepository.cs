using MiApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Repositories
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly SQLiteConnection _database;

        public TiendaRepository(SQLiteConnection database)
        {
            _database = database;
            _database.CreateTable<Tienda>();
        }

        public Task<List<Tienda>> GetAll() =>
            Task.FromResult(_database.Table<Tienda>().ToList());

        public Task Add(Tienda tienda)
        {
            _database.Insert(tienda);
            return Task.CompletedTask;
        }

    }
}
