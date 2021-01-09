using AutoMapper;
using GT.Domain.Repositories.Interfaces;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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

        // GET: api/crops
        /// <summary>
        /// Gets the crops.
        /// </summary>
        /// <returns>IEnumerable&lt;Crop&gt;.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ActionName(nameof(GetCropsAsync))]
        [ProducesResponseType(typeof(List<Crop>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCropsAsync()
        {
            _logger.LogInformation("Begin GetCropsAsync");

            var cropEntities = await _cropRepository.GetCropsAsync();

            IList<Crop> crops = new List<Crop>();

            if (cropEntities != null)
            {
                // Map entities to dtos
                crops = _mapper.Map<IList<Crop>>(cropEntities);
            }

            return Ok(crops);
        }

        // GET: api/crops/5
        /// <summary>
        /// Gets the crop.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Crop</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ActionName(nameof(GetCropAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCropAsync([FromRoute(Name = "id"), Required] int id)
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

        // PUT: api/crops/5
        /// <summary>
        /// Puts the crop.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="crop">The crop.</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ActionName(nameof(PutCropAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutCropAsync([FromRoute(Name = "id"), Required] int id, [FromBody] Crop crop)
        {
            _logger.LogInformation("Begin UpdateCropAsync");

            if (id != crop.CropId)
            {
                return BadRequest();
            }

            CropEntity cropEntity = _mapper.Map<CropEntity>(crop);

            cropEntity = await _cropRepository.UpdateCropAsync(id, cropEntity);

            if (cropEntity != null)
            {
                // Map entity to dto
                crop = _mapper.Map<Crop>(cropEntity);
            }

            return Ok(crop);
        }

        // POST: api/crops
        /// <summary>
        /// Posts the crop.
        /// </summary>
        /// <param name="crop">The crop.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        [HttpPost]
        [ActionName(nameof(PostCropAsync))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostCropAsync([FromBody] Crop crop)
        {
            _logger.LogInformation("Begin CreateCropAsync");

            CropEntity cropEntity = _mapper.Map<CropEntity>(crop);

            cropEntity = await _cropRepository.CreateCropAsync(cropEntity);

            crop = _mapper.Map<Crop>(cropEntity);

            return CreatedAtAction(nameof(GetCropAsync), "Crops", new { id = crop.GardenId }, crop);
        }

        // DELETE: api/crops/5
        /// <summary>
        /// Deletes the crop.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCropAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCropAsync([FromRoute(Name = "id"), Required] int id)
        {
            _logger.LogInformation("Begin DeleteCropAsync");

            await _cropRepository.DeleteCropAsync(id);

            return NoContent();
        }

        // GET: api/crops/5/activities
        /// <summary>
        /// Gets the crop activities.
        /// </summary>
        /// <returns>IEnumerable&lt;Crop&gt;.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("{id}/activities")]
        [ActionName(nameof(GetCropActivitiesAsync))]
        [ProducesResponseType(typeof(List<CropActivity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCropActivitiesAsync([FromRoute(Name = "id"), Required] int id)
        {
            _logger.LogInformation("Begin GetCropActivitiesAsync");

            if (id == 0)
            {
                return BadRequest("The cropId is required.");
            }

            var cropActivityEntities = await _cropRepository.GetCropActivitiesAsync(id);

            IList<CropActivity> crops = new List<CropActivity>();

            if (cropActivityEntities != null)
            {
                // Map entities to dtos
                crops = _mapper.Map<IList<CropActivity>>(cropActivityEntities);
            }

            return Ok(crops);
        }
    }
}