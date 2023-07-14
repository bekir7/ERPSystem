using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public LawController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet]
        public ActionResult<IEnumerable<LawRequest>> Get() =>
            _dbContext.LawRequests.ToList();



        [Route("Create")]
        [HttpPost]
        public IActionResult Create(LawRequest model)
        {
            var result = _dbContext.LawRequests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.LawRequests.ToList();
            return Ok(requests);
        }

       
        [Route("Update2")]
        [HttpPost]
        public IActionResult Update2(LawRequest model)
        {

            var request = _dbContext.LawRequests.Where(x => x.ArchiveId == model.ArchiveId).FirstOrDefault();
          
            request.Time = model.Time;
            request.Time2 = model.Time2;
            _dbContext.SaveChanges();
            var requests = _dbContext.LawRequests.ToList();
            return Ok(requests);
        }
    }
}
