using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Index(int code)
        {
            ///objeyi olduğu gibi dön
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
