using API.Errors;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _ctx;
        public BuggyController(StoreContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var pro = _ctx.Products.Find(5);
            var propdsa = pro.ToString();

            return Ok();
        }
        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(40));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return BadRequest();
        }
        
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var pro = _ctx.Products.Find(5);
            if (pro == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
    }
}
