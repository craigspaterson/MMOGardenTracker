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
        private readonly ILogger<GardensController> _logger;
        private readonly IMapper _mapper;
        private readonly IGardenRepository _gardenRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GardensController" /> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="gardenRepository"></param>
        public GardensController(IMapper mapper, ILogger<GardensController> logger, IGardenRepository gardenRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gardenRepository = gardenRepository ?? throw new ArgumentNullException(nameof(gardenRepository));
        }

        // GET: api/Gardens
        /// <summary>
        /// Get a list of gardens.
        /// </summary>
        /// <returns>List of garden</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ActionName(nameof(GetGardensAsync))]
        [ProducesResponseType(typeof(List<Garden>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetGardensAsync()
        {
            _logger.LogInformation("Begin GetGardensAsync");

            var gardenEntities = await _gardenRepository.GetGardensAsync();

            IList<Garden> gardens = new List<Garden>();

            if (gardenEntities != null)
            {
                // Map entities to dtos
                gardens = _mapper.Map<IList<Garden>>(gardenEntities);
            }

            return Ok(gardens);
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
        [ActionName(nameof(GetGardenAsync))]
        [ProducesResponseType(typeof(Garden), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGardenAsync([FromRoute(Name = "id"), Required] int id)
        {
            _logger.LogInformation("Begin GetGardenAsync");

            if (id == 0)
            {
                return BadRequest("The gardenId is required.");
            }

            Garden gardenDto;

            GardenEntity gardenEntity = await _gardenRepository.GetGardenAsync(id);

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
        [ActionName(nameof(PutGardenAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutGardenAsync([FromRoute(Name = "id"), Required] int id, [FromBody][Required] Garden garden)
        {
            _logger.LogInformation("Begin UpdateGardenAsync");

            if (id != garden.GardenId)
            {
                return BadRequest();
            }

            GardenEntity gardenEntity = _mapper.Map<GardenEntity>(garden);

            gardenEntity = await _gardenRepository.UpdateGardenAsync(id, gardenEntity);

            if (gardenEntity != null)
            {
                // Map entity to dto
                garden = _mapper.Map<Garden>(gardenEntity);
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
        [ActionName(nameof(PostGardenAsync))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostGardenAsync([FromBody][Required] Garden garden)
        {
            _logger.LogInformation("Begin CreateGardenAsync");

            GardenEntity gardenEntity = _mapper.Map<GardenEntity>(garden);

            gardenEntity = await _gardenRepository.CreateGardenAsync(gardenEntity);

            garden = _mapper.Map<Garden>(gardenEntity);

            return CreatedAtAction(nameof(GetGardenAsync),"Gardens", new { id = garden.GardenId }, garden);
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
        [ActionName(nameof(DeleteGardenAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteGardenAsync([FromRoute(Name = "id"), Required] int id)
        {
            _logger.LogInformation("Begin DeleteGardenAsync");

            await _gardenRepository.DeleteGardenAsync(id);

            return NoContent();
        }
    }
}