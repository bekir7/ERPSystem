using alisanljoj.DTOs;
using alisanljoj.Model;
using alisanljoj.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaRequestController : ControllerBase
    {
        private readonly IGenericRepository<FaturaRequest> _repository;
        private readonly ILogger<FaturaRequestController> _logger;

        public FaturaRequestController(IGenericRepository<FaturaRequest> repository, ILogger<FaturaRequestController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all fatura requests
        /// </summary>
        /// <returns>List of all fatura requests</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RequestDto>), 200)]
        public async Task<ActionResult<IEnumerable<RequestDto>>> Get()
        {
            try
            {
                _logger.LogInformation("Getting all fatura requests");
                var requests = await _repository.GetAllAsync();
                var requestDtos = requests.Select(MapToDto);
                return Ok(requestDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all fatura requests");
                throw;
            }
        }

        /// <summary>
        /// Gets a fatura request by ID
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>Fatura request details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RequestDto>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting fatura request with ID: {RequestId}", id);
                var request = await _repository.GetByIdAsync(id);
                if (request == null)
                {
                    _logger.LogWarning("Fatura request with ID {RequestId} not found", id);
                    return NotFound();
                }
                return Ok(MapToDto(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting fatura request with ID: {RequestId}", id);
                throw;
            }
        }

        /// <summary>
        /// Creates a new fatura request
        /// </summary>
        /// <param name="createDto">Fatura request creation data</param>
        /// <returns>Created fatura request</returns>
        [HttpPost("CreateFatura")]
        [ProducesResponseType(typeof(RequestDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RequestDto>> Create([FromBody] CreateRequestDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for fatura request creation");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Creating new fatura request for requestor: {Requestor}", createDto.Requestor);
                var request = MapFromCreateDto(createDto);
                var createdRequest = await _repository.AddAsync(request);
                var requestDto = MapToDto(createdRequest);
                
                _logger.LogInformation("Fatura request created successfully with ID: {RequestId}", createdRequest.RequestId);
                return CreatedAtAction(nameof(GetById), new { id = createdRequest.RequestId }, requestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating fatura request");
                throw;
            }
        }

        /// <summary>
        /// Deletes a fatura request
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting fatura request with ID: {RequestId}", id);
                var deleted = await _repository.DeleteAsync(id);
                if (!deleted)
                {
                    _logger.LogWarning("Fatura request with ID {RequestId} not found for deletion", id);
                    return NotFound();
                }
                
                _logger.LogInformation("Fatura request deleted successfully with ID: {RequestId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting fatura request with ID: {RequestId}", id);
                throw;
            }
        }

        private static RequestDto MapToDto(FaturaRequest request)
        {
            return new RequestDto
            {
                RequestId = request.RequestId,
                RequestNo = request.RequestNo,
                Requestor = request.Requestor,
                RequestDate = request.RequestDate,
                RequestCategory = request.RequestCategory,
                RequestDepot = request.RequestDepot,
                RequestSupplier = request.RequestSupplier,
                RequestMaterial = request.RequestMaterial,
                RequestPaymentType = request.RequestPaymentType,
                RequestPieces = request.RequestPieces,
                RequestDescription = request.RequestDescription
            };
        }

        private static FaturaRequest MapFromCreateDto(CreateRequestDto dto)
        {
            return new FaturaRequest
            {
                RequestNo = dto.RequestNo,
                Requestor = dto.Requestor,
                RequestDate = dto.RequestDate,
                RequestCategory = dto.RequestCategory,
                RequestDepot = dto.RequestDepot,
                RequestSupplier = dto.RequestSupplier,
                RequestMaterial = dto.RequestMaterial,
                RequestPaymentType = dto.RequestPaymentType,
                RequestPieces = dto.RequestPieces,
                RequestDescription = dto.RequestDescription
            };
        }
    }
}
