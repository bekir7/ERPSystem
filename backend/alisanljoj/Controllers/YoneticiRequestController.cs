using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoneticiRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public YoneticiRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<YoneticiRequest>> GetBt() =>
            _dbContext.YoneticiRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<YoneticiRequest>> GetById(int id)
        {
            var request = await _dbContext.YoneticiRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateYonetici")]
        [HttpPost]
        public IActionResult CreateBt(YoneticiRequest model)
        {
            var result = _dbContext.YoneticiRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.YoneticiRequests.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<YoneticiRequest>> Delete(int id)
        {
            var request = await _dbContext.YoneticiRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.YoneticiRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.YoneticiRequests.ToListAsync();
            return request;
        }
    }
}
