using System;
using System.Net;
using System.Web.Http;

namespace FullFrameworkLoggingUsingFilter.Controllers
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

        [HttpGet]
        [Route("throwservererror")]
        public IHttpActionResult ThrowServerError()
        {
            throw new Exception("This is not safe for outside, but...");
        }
    }
}
