using System;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreLogging.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(new {a = 123});
        }

        [HttpGet]
        [Route("throw")]
        public IActionResult Throw()
        {
            throw new SafeForWorldOutsideException();
        }

        [HttpGet]
        [Route("throwservererror")]
        public IActionResult ThrowServerError()
        {
            throw new Exception("This is not safe for outside, but...");
        }
    }
}