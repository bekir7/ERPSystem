using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KargoRequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public KargoRequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<KargoRequest>> GetBt() =>
            _dbContext.KargoRequests.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<KargoRequest>> GetById(int id)
        {
            var request = await _dbContext.KargoRequests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateKargo")]
        [HttpPost]
        public IActionResult CreateBt(KargoRequest model)
        {
            var result = _dbContext.KargoRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.KargoRequests.ToList();
            return Ok(requests);
        }

        [Route("Update4")]
        [HttpPost]
        public IActionResult Update3(KargoRequest model)
        {

            var request = _dbContext.KargoRequests.Where(x => x.RequestNo == model.RequestNo).FirstOrDefault();
            request.Status = model.Status;


            _dbContext.SaveChanges();
            var requests = _dbContext.KargoRequests.ToList();
            return Ok(requests);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<KargoRequest>> Delete(int id)
        {
            var request = await _dbContext.KargoRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.KargoRequests.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.KargoRequests.ToListAsync();
            return request;
        }
    }
}
