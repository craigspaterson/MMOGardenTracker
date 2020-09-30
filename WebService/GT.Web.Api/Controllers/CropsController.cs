﻿using AutoMapper;
using GT.Domain;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CropsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper"></param>
        public CropsController(GardenTrackerAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Crops
        /// <summary>
        /// Gets the crops.
        /// </summary>
        /// <returns>IEnumerable&lt;Crop&gt;.</returns>
        [HttpGet]
        public async Task<IList<Crop>> GetCropsAsync()
        {
            IList<Crop> crops = new List<Crop>();

            IList<CropEntity> cropEntities= await _context.Crops.AsNoTracking().ToListAsync();

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
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCropAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Crop cropDto;
            CropEntity cropEntity = await _context.Crops.FindAsync(id);

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
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCropAsync([FromRoute] int id, [FromBody] Crop crop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        public async Task<IActionResult> PostCropAsync([FromBody] Crop crop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCropAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }

            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();

            return Ok(crop);
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