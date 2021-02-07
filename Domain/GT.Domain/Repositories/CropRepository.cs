using GT.Domain.Models;
using GT.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GT.Common.Exceptions;

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
        /// <param name="logger"></param>
        public CropRepository(GardenTrackerAppContext context, ILogger<CropRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Crop>> GetCropsAsync()
        {
            _logger.LogInformation("Begin GetCropsAsync from CropRepository");

            return await _context.Crops
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Crop> GetCropAsync(int id)
        {
            _logger.LogInformation("Begin GetCropAsync from CropRepository");

            try
            {
                var crop = await _context.Crops
                    .Include(x => x.CropActivities)
                    .AsNoTracking()
                    .SingleAsync(x => x.CropId == id);

                return crop;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException($"The Crop with Id: {id} was not found.");
            }
        }

        public async Task<Crop> CreateCropAsync(Crop crop)
        {
            _logger.LogInformation("Begin CreateCropAsync from CropRepository");

            // Validate the CropActivities
            if (crop.CropActivities != null)
            {
                foreach (var cropCropActivity in crop.CropActivities)
                {
                    if (cropCropActivity.ActivityDate < crop.BeginDate || cropCropActivity.ActivityDate > crop.EndDate)
                    {
                        throw new BadRequestException("The Crop Activity Date is out of range.");
                    }
                }
            }

            //_context.Attach(crop).State = EntityState.Added;

            //_context.ChangeTracker.TrackGraph(crop, x => x.Entry.State = EntityState.Added);

            await _context.Crops.AddAsync(crop);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CropExists(crop.CropId))
                {
                    throw new ConflictException("The Crop already exists.");
                }

                throw;
            }

            return crop;
        }

        public async Task<Crop> UpdateCropAsync(int id, Crop crop)
        {
            _logger.LogInformation("Begin UpdateCropAsync from CropRepository");

            if (id != crop.CropId)
            {
                throw new BadRequestException($"The Crop with Id: {id} was not found.");
            }

            _context.Entry(crop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!CropExists(id))
                {
                    throw new NotFoundException($"The Crop with Id: {id} was not found.");
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

        public async Task<IEnumerable<CropActivity>> GetCropActivitiesAsync(int id)
        {
            _logger.LogInformation("Begin GetCropActivitiesAsync from CropRepository");

            return await _context.CropActivities
                .AsNoTracking()
                .Where(x => x.CropId == id)
                .ToListAsync();
        }

        private bool CropExists(int id)
        {
            return _context.Crops.Any(e => e.CropId == id);
        }
    }
}