using System.Net;
using System.Web.Http;

namespace FullFrameworkLoggingUsingOwin.Controllers
{
    [RoutePrefix("api/vehicles")]
    public class VehiclesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(new {a = 123});
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post()
        {
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("throw")]
        public IHttpActionResult Throw()
        {
            throw new SafeForWorldOutsideException();
        }
    }
}