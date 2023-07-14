using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HukukSonucController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public HukukSonucController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<HukukSonuc>> Get() =>
            _dbContext.HukukSonucs.ToList();



        [Route("Create")]
        [HttpPost]
        public IActionResult Create(HukukSonuc model)
        {
            var result = _dbContext.HukukSonucs.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.HukukSonucs.ToList();
            return Ok(requests);
        }


        [Route("Update2")]
        [HttpPost]
        public IActionResult Update2(HukukSonuc model)
        {

            var request = _dbContext.HukukSonucs.Where(x => x.ArchiveId == model.ArchiveId).FirstOrDefault();
            request.result = model.result;


            _dbContext.SaveChanges();
            var requests = _dbContext.HukukSonucs.ToList();
            return Ok(requests);
        }



        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<HukukSonuc>> Delete(int id)
        {
            var request = await _dbContext.HukukSonucs.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _dbContext.HukukSonucs.Remove(request);
            await _dbContext.SaveChangesAsync();
            await _dbContext.HukukSonucs.ToListAsync();
            return request;

        }
    }
}
