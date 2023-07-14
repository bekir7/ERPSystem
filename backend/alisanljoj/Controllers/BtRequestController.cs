using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BtRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public BtRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<BtRequest>> GetBt() =>
            _dbContext.BtRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<BtRequest>> GetById(int id)
        {
            var request = await _dbContext.BtRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateBt")]
        [HttpPost]
        public IActionResult CreateBt(BtRequest model)
        {
            var result = _dbContext.BtRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.BtRequests.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<BtRequest>> Delete(int id)
        {
            var request = await _dbContext.BtRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.BtRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.BtRequests.ToListAsync();
            return request;
        }
    }
}
