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
            catch (InvalidOperationException)
            {
                throw new NotFoundException($"The Garden with Id: {id} was not found.");
            }
        }

        public async Task<Garden> CreateGardenAsync(Garden garden)
        {
            _logger.LogInformation("Begin CreateGardenAsync from GardenRepository");

            await _context.Gardens.AddAsync(garden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GardenExists(garden.GardenId))
                {
                    throw new ConflictException("The Garden already exists.");
                }

                if (GardenNameExists(garden.GardenName))
                {
                    throw new ConflictException("The Garden Name already exists.");
                }

                throw;
            }

            return garden;
        }

        public async Task<Garden> UpdateGardenAsync(int id, Garden garden)
        {
            _logger.LogInformation("Begin UpdateGardenAsync from GardenRepository");

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
                    throw new NotFoundException($"The Garden with Id: {id} was not found.");
                }

                throw;
            }
            catch (DbUpdateException)
            {
                if (GardenNameExists(garden.GardenName))
                {
                    throw new ConflictException("The Garden Name already exists.");
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

        private bool GardenNameExists(string gardenName)
        {
            return _context.Gardens.Any(e => e.GardenName == gardenName);
        }
    }
}