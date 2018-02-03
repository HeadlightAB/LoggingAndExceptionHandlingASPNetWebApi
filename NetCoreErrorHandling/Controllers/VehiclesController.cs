using Microsoft.AspNetCore.Mvc;

namespace NetCoreErrorHandling.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(new { a = 123 });
        }
    }
}
