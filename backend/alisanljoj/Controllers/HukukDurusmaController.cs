using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HukukDurusmaController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public HukukDurusmaController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<HukukDurusma>> Get() =>
            _dbContext.HukukDurusmas.ToList();



        [Route("Create")]
        [HttpPost]
        public IActionResult Create(HukukDurusma model)
        {
            var result = _dbContext.HukukDurusmas.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.HukukDurusmas.ToList();
            return Ok(requests);
        }


        [Route("Update2")]
        [HttpPost]
        public IActionResult Update2(HukukDurusma model)
        {

            var request = _dbContext.HukukDurusmas.Where(x => x.ArchiveId == model.ArchiveId).FirstOrDefault();
            request.Time = model.Time;
            request.Time2 = model.Time2;

            _dbContext.SaveChanges();
            var requests = _dbContext.HukukDurusmas.ToList();
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
