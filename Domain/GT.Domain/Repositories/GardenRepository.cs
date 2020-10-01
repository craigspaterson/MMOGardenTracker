using GT.Domain.Models;
using GT.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.Domain.Repositories
{
    /// <summary>
    /// Class GardenRepository.
    /// </summary>
    public class GardenRepository : IGardenRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GardenTrackerAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GardenRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GardenRepository(GardenTrackerAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Garden>> GetGardensAsync()
        {
            return await _context.Gardens
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Garden> GetGardenAsync(int id)
        {
            // Validation

            var garden = await _context.Gardens
                .Include(x => x.Crops)
                .AsNoTracking()
                .SingleAsync(x => x.GardenId == id);

            return garden;
        }

        public async Task<Crop> PutGardenAsync(int id, Garden garden)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Crop> PostGardenAsync(Garden garden)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteGardenAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}