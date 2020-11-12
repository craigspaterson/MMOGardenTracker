using AutoMapper;
using GT.Domain;
using GT.Domain.Repositories;
using GT.Domain.Repositories.Interfaces;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardenEntity = GT.Domain.Models.Garden;

namespace GT.Web.Api.Controllers
{
    /// <summary>
    /// Class GardensController.
    /// </summary>
    [Route("api/gardens")]
    [Produces("application/json")]
    [ApiController]
    public class GardensController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GardenTrackerAppContext _context;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GardensController> _logger;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GardensController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public GardensController(GardenTrackerAppContext context, IMapper mapper, ILogger<GardensController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Gardens
        /// <summary>
        /// Get a list of gardens.
        /// </summary>
        /// <returns>List of garden</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Garden>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IList<Garden>> GetGardensAsync()
        {
            IGardenRepository gardenRepository = new GardenRepository(_context);
            IEnumerable<GardenEntity> gardenEntities = await gardenRepository.GetGardensAsync();

            IList<Garden> gardens = new List<Garden>();

            _logger.LogInformation("Begin GetGardensAsync");

            if (gardenEntities != null)
            {
                // Map entities to dtos
                gardens = _mapper.Map<IList<Garden>>(gardenEntities);
            }

            return gardens;
        }

        // GET: api/Gardens/5
        /// <summary>
        /// Get a single garden.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Garden</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Garden), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGardenAsync([FromRoute] int id)
        {
            _logger.LogInformation("Begin GetGardenAsync");

            if (id == 0)
            {
                return BadRequest("The gardenId is required.");
            }

            Garden gardenDto;
            IGardenRepository gardenRepository = new GardenRepository(_context);

            GardenEntity gardenEntity = await gardenRepository.GetGardenAsync(id);

            if (gardenEntity != null)
            {
                // Map entity to dto
                gardenDto = _mapper.Map<Garden>(gardenEntity);
            }
            else
            {
                return NotFound();
            }

            return Ok(gardenDto);
        }

        // PUT: api/Gardens/5
        /// <summary>
        /// Updates the garden.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="garden">The garden.</param>
        /// <response code="200">OK</response>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutGardenAsync([FromRoute] int id, [FromBody] Garden garden)
        {
            _logger.LogInformation("Begin PutGardenAsync");

            if (id != garden.GardenId)
            {
                return BadRequest();
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
                    return NotFound();
                }

                throw;
            }

            return Ok(garden);
        }

        // POST: api/Gardens
        /// <summary>
        /// Posts the garden.
        /// </summary>
        /// <param name="garden">The garden.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostGardenAsync([FromBody] Garden garden)
        {
            _logger.LogInformation("Begin PostGardenAsync");

            GardenEntity gardenEntity = _mapper.Map<GardenEntity>(garden);
            await _context.Gardens.AddAsync(gardenEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GardenExists(garden.GardenId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }

                throw;
            }

            return CreatedAtAction("GetGardenAsync", new { id = garden.GardenId }, garden);
        }

        // DELETE: api/Gardens/5
        /// <summary>
        /// Deletes the garden.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteGardenAsync([FromRoute] int id)
        {
            _logger.LogInformation("Begin DeleteGardenAsync");

            var garden = await _context.Gardens.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }

            _context.Gardens.Remove(garden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gardens the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if garden, <c>false</c> otherwise.</returns>
        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenId == id);
        }
    }
}