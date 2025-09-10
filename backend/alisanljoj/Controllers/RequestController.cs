using alisanljoj.DTOs;
using alisanljoj.Model;
using alisanljoj.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IGenericRepository<Request> _repository;
        private readonly ILogger<RequestController> _logger;

        public RequestController(IGenericRepository<Request> repository, ILogger<RequestController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all requests
        /// </summary>
        /// <returns>List of all requests</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RequestDto>), 200)]
        public async Task<ActionResult<IEnumerable<RequestDto>>> Get()
        {
            try
            {
                _logger.LogInformation("Getting all requests");
                var requests = await _repository.GetAllAsync();
                var requestDtos = requests.Select(MapToDto);
                return Ok(requestDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all requests");
                throw;
            }
        }

        /// <summary>
        /// Gets a request by ID
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>Request details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RequestDto>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting request with ID: {RequestId}", id);
                var request = await _repository.GetByIdAsync(id);
                if (request == null)
                {
                    _logger.LogWarning("Request with ID {RequestId} not found", id);
                    return NotFound();
                }
                return Ok(MapToDto(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting request with ID: {RequestId}", id);
                throw;
            }
        }

        /// <summary>
        /// Creates a new request
        /// </summary>
        /// <param name="createDto">Request creation data</param>
        /// <returns>Created request</returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(RequestDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RequestDto>> Create([FromBody] CreateRequestDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for request creation");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Creating new request for requestor: {Requestor}", createDto.Requestor);
                var request = MapFromCreateDto(createDto);
                var createdRequest = await _repository.AddAsync(request);
                var requestDto = MapToDto(createdRequest);
                
                _logger.LogInformation("Request created successfully with ID: {RequestId}", createdRequest.RequestId);
                return CreatedAtAction(nameof(GetById), new { id = createdRequest.RequestId }, requestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating request");
                throw;
            }
        }

        /// <summary>
        /// Updates request status (first approval level)
        /// </summary>
        /// <param name="updateDto">Status update data</param>
        /// <returns>Updated request</returns>
        [HttpPost("Update2")]
        [ProducesResponseType(typeof(RequestDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RequestDto>> Update2([FromBody] UpdateRequestStatusDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for request status update");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Updating request status for request number: {RequestNo}", updateDto.RequestNo);
                var request = await _repository.GetByRequestNoAsync(updateDto.RequestNo);
                if (request == null)
                {
                    _logger.LogWarning("Request with number {RequestNo} not found", updateDto.RequestNo);
                    return NotFound();
                }

                request.Status = updateDto.Status;
                request.DescriptionDeny = updateDto.DescriptionDeny;
                
                var updatedRequest = await _repository.UpdateAsync(request);
                var requestDto = MapToDto(updatedRequest);
                
                _logger.LogInformation("Request status updated successfully for request number: {RequestNo}", updateDto.RequestNo);
                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating request status for request number: {RequestNo}", updateDto.RequestNo);
                throw;
            }
        }

        /// <summary>
        /// Updates request status (second approval level)
        /// </summary>
        /// <param name="updateDto">Status update data</param>
        /// <returns>Updated request</returns>
        [HttpPost("Update3")]
        [ProducesResponseType(typeof(RequestDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RequestDto>> Update3([FromBody] UpdateRequestStatusDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for request status update");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Updating request status (level 2) for request number: {RequestNo}", updateDto.RequestNo);
                var request = await _repository.GetByRequestNoAsync(updateDto.RequestNo);
                if (request == null)
                {
                    _logger.LogWarning("Request with number {RequestNo} not found", updateDto.RequestNo);
                    return NotFound();
                }

                request.Status = updateDto.Status;
                request.DescriptionDeny2 = updateDto.DescriptionDeny2;
                
                var updatedRequest = await _repository.UpdateAsync(request);
                var requestDto = MapToDto(updatedRequest);
                
                _logger.LogInformation("Request status updated successfully (level 2) for request number: {RequestNo}", updateDto.RequestNo);
                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating request status (level 2) for request number: {RequestNo}", updateDto.RequestNo);
                throw;
            }
        }

        /// <summary>
        /// Deletes a request
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
                _logger.LogInformation("Deleting request with ID: {RequestId}", id);
                var deleted = await _repository.DeleteAsync(id);
                if (!deleted)
                {
                    _logger.LogWarning("Request with ID {RequestId} not found for deletion", id);
                    return NotFound();
                }
                
                _logger.LogInformation("Request deleted successfully with ID: {RequestId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting request with ID: {RequestId}", id);
                throw;
            }
        }

        private static RequestDto MapToDto(Request request)
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
                RequestDescription = request.RequestDescription,
                Status = request.Status,
                DescriptionDeny = request.DescriptionDeny,
                DescriptionDeny2 = request.DescriptionDeny2
            };
        }

        private static Request MapFromCreateDto(CreateRequestDto dto)
        {
            return new Request
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
