using alisanljoj.Data;
using alisanljoj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestContext _dbContext;
        public RequestController(RequestContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Request>> Get() =>
            _dbContext.Requests.ToList();



        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Request model)
        {
            var result = _dbContext.Requests.Add(model);
            _dbContext.SaveChanges();
            var requests = _dbContext.Requests.ToList();
            return Ok(requests);
        }


        [Route("Update2")]
        [HttpPost]
        public IActionResult Update2(Request model)
        {

            var request = _dbContext.Requests.Where(x => x.RequestNo == model.RequestNo ).FirstOrDefault();
            request.Status = model.Status;
            request.DescriptionDeny = model.DescriptionDeny;
            
            _dbContext.SaveChanges();
            var requests = _dbContext.Requests.ToList();
            return Ok(requests);
        }

        [Route("Update3")]
        [HttpPost]
        public IActionResult Update3(Request model)
        {

            var request = _dbContext.Requests.Where(x => x.RequestNo == model.RequestNo).FirstOrDefault();
            request.Status = model.Status;
            request.DescriptionDeny2 = model.DescriptionDeny2;

            _dbContext.SaveChanges();
            var requests = _dbContext.Requests.ToList();
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
