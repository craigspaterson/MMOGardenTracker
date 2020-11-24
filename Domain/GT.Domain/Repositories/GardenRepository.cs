using GT.Domain.Models;
using GT.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.Domain.Repositories
{
    /// <summary>
    /// Class GardenRepository.
    /// </summary>
    public class GardenRepository : IGardenRepository
    {
        private readonly GardenTrackerAppContext _context;
        private readonly ILogger<GardenRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GardenRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger"></param>
        public GardenRepository(GardenTrackerAppContext context, ILogger<GardenRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Garden>> GetGardensAsync()
        {
            return await _context.Gardens
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Garden> GetGardenAsync(int id)
        {
            _logger.LogInformation("Begin GetGardenAsync from GardenRepository");

            try
            {
                var garden = await _context.Gardens
                    .Include(x => x.Crops)
                    .AsNoTracking()
                    .SingleAsync(x => x.GardenId == id);

                return garden;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
            }

            return null;
        }

        public async Task<Garden> PostGardenAsync(Garden garden)
        {
            _logger.LogInformation("Begin PostGardenAsync from GardenRepository");

            await _context.Gardens.AddAsync(garden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GardenExists(garden.GardenId))
                {
                    //return new StatusCodeResult(StatusCodes.Status409Conflict);
                }

                throw;
            }

            return garden;
        }

        public async Task<Garden> PutGardenAsync(int id, Garden garden)
        {
            _logger.LogInformation("Begin PutGardenAsync from GardenRepository");

            if (id != garden.GardenId)
            {
                return null;
            }

            _context.Entry(garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenExists(id))
                {
                    //return NotFound();
                }

                throw;
            }

            return garden;
        }

        public async Task DeleteGardenAsync(int id)
        {
            _logger.LogInformation("Begin Delete GardenAsync from GardenRepository");

            var garden = await _context.Gardens.FindAsync(id);
            if (garden != null)
            {
                _context.Gardens.Remove(garden);
                await _context.SaveChangesAsync();
            }
        }

        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenId == id);
        }
    }
}