using System.Collections.Generic;
using System.Threading.Tasks;
using GT.Domain.Models;

namespace GT.Domain.Repositories.Interfaces
{
    public interface ICropRepository
    {
        Task<IEnumerable<Crop>> GetCropsAsync();
        Task<Crop> GetCropAsync(int id);

        Task<Crop> PutCropAsync(int id, Crop crop);
        Task<Crop> PostCropAsync(Crop crop);
        Task DeleteCropAsync(int id);
    }
}