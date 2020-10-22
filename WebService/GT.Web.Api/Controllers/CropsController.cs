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
using CropEntity = GT.Domain.Models.Crop;

namespace GT.Web.Api.Controllers
{
    /// <summary>
    /// Class CropsController.
    /// </summary>
    [Route("api/crops")]
    [Produces("application/json")]
    [ApiController]
    public class CropsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GardenTrackerAppContext _context;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<CropsController> _logger;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CropsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CropsController(GardenTrackerAppContext context, IMapper mapper, ILogger<CropsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Crops
        /// <summary>
        /// Gets the crops.
        /// </summary>
        /// <returns>IEnumerable&lt;Crop&gt;.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Crop>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IList<Crop>> GetCropsAsync()
        {
            ICropRepository cropRepository = new CropRepository(_context);
            IEnumerable<CropEntity> cropEntities = await cropRepository.GetCropsAsync();

            IList<Crop> crops = new List<Crop>();

            _logger.LogInformation("Begin GetCropsAsync");

            if (cropEntities != null)
            {
                // Map entities to dtos
                crops = _mapper.Map<IList<Crop>>(cropEntities);
            }

            return crops;
        }

        // GET: api/Crops/5
        /// <summary>
        /// Gets the crop.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Crop</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCropAsync([FromRoute] int id)
        {
            _logger.LogInformation("Begin GetCropAsync");

            if (id == 0)
            {
                return BadRequest("The cropId is required.");
            }

            Crop cropDto;
            ICropRepository cropRepository = new CropRepository(_context);

            CropEntity cropEntity = await cropRepository.GetCropAsync(id);

            if (cropEntity != null)
            {
                // Map entity to dto
                cropDto = _mapper.Map<Crop>(cropEntity);
            }
            else
            {
                return NotFound();
            }

            return Ok(cropDto);
        }

        // PUT: api/Crops/5
        /// <summary>
        /// Puts the crop.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="crop">The crop.</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCropAsync([FromRoute] int id, [FromBody] Crop crop)
        {
            _logger.LogInformation("Begin PutCropAsync");

            if (id != crop.CropId)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Crops
        /// <summary>
        /// Posts the crop.
        /// </summary>
        /// <param name="crop">The crop.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostCropAsync([FromBody] Crop crop)
        {
            _logger.LogInformation("Begin PostCropAsync");

            CropEntity cropEntity = _mapper.Map<CropEntity>(crop);
            await _context.Crops.AddAsync(cropEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CropExists(crop.CropId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCropAsync", new { id = crop.CropId }, crop);
        }

        // DELETE: api/Crops/5
        /// <summary>
        /// Deletes the crop.
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
        public async Task<IActionResult> DeleteCropAsync([FromRoute] int id)
        {
            _logger.LogInformation("Begin DeleteCropAsync");

            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }

            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Crops the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if crop, <c>false</c> otherwise.</returns>
        private bool CropExists(int id)
        {
            return _context.Crops.Any(e => e.CropId == id);
        }
    }
}