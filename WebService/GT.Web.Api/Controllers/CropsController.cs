using AutoMapper;
using GT.Domain.Repositories.Interfaces;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly ILogger<CropsController> _logger;
        private readonly IMapper _mapper;
        private readonly ICropRepository _cropRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CropsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="cropRepository"></param>
        public CropsController(IMapper mapper, ILogger<CropsController> logger, ICropRepository cropRepository)
        {
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cropRepository = cropRepository;
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
            _logger.LogInformation("Begin GetCropsAsync");

            var cropEntities = await _cropRepository.GetCropsAsync();

            IList<Crop> crops = new List<Crop>();

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
            CropEntity cropEntity = await _cropRepository.GetCropAsync(id);

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
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            CropEntity cropEntity = _mapper.Map<CropEntity>(crop);

            cropEntity = await _cropRepository.PutCropAsync(id, cropEntity);

            if (cropEntity != null)
            {
                // Map entity to dto
                crop = _mapper.Map<Crop>(cropEntity);
            }

            return Ok(crop);
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
            _logger.LogInformation("Begin PostGardenAsync");

            CropEntity cropEntity = _mapper.Map<CropEntity>(crop);

            cropEntity = await _cropRepository.PostCropAsync(cropEntity);

            crop = _mapper.Map<Crop>(cropEntity);

            return CreatedAtAction("GetCropAsync", new { id = crop.GardenId }, crop);
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

            await _cropRepository.DeleteCropAsync(id);

            return NoContent();
        }
    }
}