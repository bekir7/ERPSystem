using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KargoYoneticiController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public KargoYoneticiController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<KargoYonetici>> GetBt() =>
            _dbContext.KargoYoneticis.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<KargoYonetici>> GetById(int id)
        {
            var request = await _dbContext.KargoYoneticis.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        [Route("CreateKargoYonetici")]
        [HttpPost]
        public IActionResult CreateBt(KargoYonetici model)
        {
            var result = _dbContext.KargoYoneticis.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.KargoYoneticis.ToList();
            return Ok(requests);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<KargoYonetici>> Delete(int id)
        {
            var request = await _dbContext.KargoYoneticis.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.KargoYoneticis.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.KargoYoneticis.ToListAsync();
            return request;
        }
    }
}
