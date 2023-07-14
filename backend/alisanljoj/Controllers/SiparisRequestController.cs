using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public SiparisRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<SiparisRequest>> GetBt() =>
            _dbContext.SiparisRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<SiparisRequest>> GetById(int id)
        {
            var request = await _dbContext.SiparisRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateSiparis")]
        [HttpPost]
        public IActionResult CreateBt(SiparisRequest model)
        {
            var result = _dbContext.SiparisRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.SiparisRequests.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<SiparisRequest>> Delete(int id)
        {
            var request = await _dbContext.SiparisRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.SiparisRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.SiparisRequests.ToListAsync();
            return request;
        }
    }
}
