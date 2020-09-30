using System.Collections.Generic;
using System.Threading.Tasks;
using GT.Domain.Models;

namespace GT.Domain.Repositories.Interfaces
{
    public interface IGardenRepository
    {
        Task<IEnumerable<Garden>> GetGardensAsync();
        Task<Garden> GetGardenAsync(int id);
    }
}