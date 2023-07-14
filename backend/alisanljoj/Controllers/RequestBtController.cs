using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestBtController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public RequestBtController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet]
        public ActionResult<IEnumerable<RequestBt>> Get() =>
            _dbContext.RequestBts.ToList();



        [Route("Create")]
        [HttpPost]
        public IActionResult Create(RequestBt model)
        {
            var result = _dbContext.RequestBts.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.RequestBts.ToList();
            return Ok(requests);
        }


        [Route("Update2")]
        [HttpPost]
        public IActionResult Update2(RequestBt model)
        {

            var request = _dbContext.RequestBts.Where(x => x.RequestNo == model.RequestNo).FirstOrDefault();
            request.Status = model.Status;
            request.DescriptionDeny = model.DescriptionDeny;
            request.DescriptionDenyIt = model.DescriptionDenyIt;
            _dbContext.SaveChanges();
            var requests = _dbContext.RequestBts.ToList();
            return Ok(requests);
        }
    }
}
