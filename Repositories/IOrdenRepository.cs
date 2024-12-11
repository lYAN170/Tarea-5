using MiApp.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.Repositories
{
    public interface IOrdenRepository
    {
        Task<List<Orden>> GetAll();
        Task<int> Add(Orden orden);
        Task<int> Update(Orden orden);
        Task<int> Delete(int id);
    }
}
