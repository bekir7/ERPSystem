using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public ItRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<ItRequest>> GetBt() =>
            _dbContext.ItRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<ItRequest>> GetById(int id)
        {
            var request = await _dbContext.ItRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateIt")]
        [HttpPost]
        public IActionResult CreateBt(ItRequest model)
        {
            var result = _dbContext.ItRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.ItRequests.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ItRequest>> Delete(int id)
        {
            var request = await _dbContext.ItRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.ItRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.ItRequests.ToListAsync();
            return request;
        }
    }
}
