using GT.Domain.Models;
using GT.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace GT.Domain.Repositories
{
    public class CropRepository : ICropRepository
    {
        private readonly GardenTrackerAppContext _context;
        private readonly ILogger<CropRepository> _logger;

        /// <summary>Garden
        /// Initializes a new instance of the <see cref="CropRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CropRepository(GardenTrackerAppContext context, ILogger<CropRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Crop>> GetCropsAsync()
        {
            return await _context.Crops
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Crop> GetCropAsync(int id)
        {
            _logger.LogInformation("Begin GetGardenAsync from GardenRepository");

            try
            {
                var crop = await _context.Crops
                    .Include(x => x.CropActivities)
                    .AsNoTracking()
                    .SingleAsync(x => x.CropId == id);

                return crop;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
            }

            return null;
        }

        public async Task<Crop> PostCropAsync(Crop crop)
        {
            _logger.LogInformation("Begin PostCropAsync from CropRepository");

            // Validate the CropActivities
            if (crop.CropActivities != null)
            {
                foreach (var cropCropActivity in crop.CropActivities)
                {
                    if (cropCropActivity.ActivityDate < crop.BeginDate || cropCropActivity.ActivityDate > crop.EndDate)
                    {
                        throw new ArgumentOutOfRangeException($"ActivityDate", "The Crop Activity Date is out of range.");
                    }
                }
            }

            await _context.Crops.AddAsync(crop);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CropExists(crop.CropId))
                {
                    //return new StatusCodeResult(StatusCodes.Status409Conflict);
                }

                throw;
            }

            return crop;
        }

        public async Task<Crop> PutCropAsync(int id, Crop crop)
        {
            _logger.LogInformation("Begin PutCropAsync from CropRepository");

            if (id != crop.CropId)
            {
                return null;
            }

            _context.Entry(crop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CropExists(id))
                {
                    //return NotFound();
                }

                throw;
            }

            return crop;
        }

        public async Task DeleteCropAsync(int id)
        {
            _logger.LogInformation("Begin Delete CropAsync from CropRepository");

            var crop = await _context.Crops.FindAsync(id);
            if (crop != null)
            {
                _context.Crops.Remove(crop);
                await _context.SaveChangesAsync();
            }
        }

        private bool CropExists(int id)
        {
            return _context.Crops.Any(e => e.CropId == id);
        }
    }
}