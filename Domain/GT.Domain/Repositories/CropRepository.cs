using GT.Domain.Models;
using GT.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.Domain.Repositories
{
    public class CropRepository : ICropRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GardenTrackerAppContext _context;

        /// <summary>Garden
        /// Initializes a new instance of the <see cref="CropRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CropRepository(GardenTrackerAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Crop>> GetCropsAsync()
        {
            return await _context.Crops
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Crop> GetCropAsync(int id)
        {
            // Validation

            var crop = await _context.Crops
                .Include(x => x.CropActivities)
                .AsNoTracking()
                .SingleAsync(x => x.CropId == id);

            return crop;
        }

        public async Task<Crop> PutCropAsync(int id, Crop crop)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Crop> PostCropAsync(Crop crop)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteCropAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}