using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public FaturaRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<FaturaRequest>> GetBt() =>
            _dbContext.FaturaRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<FaturaRequest>> GetById(int id)
        {
            var request = await _dbContext.FaturaRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateFatura")]
        [HttpPost]
        public IActionResult CreateBt(FaturaRequest model)
        {
            var result = _dbContext.FaturaRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.FaturaRequests.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<FaturaRequest>> Delete(int id)
        {
            var request = await _dbContext.FaturaRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.FaturaRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.FaturaRequests.ToListAsync();
            return request;
        }
    }
}
