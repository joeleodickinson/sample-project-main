using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage Found(object obj)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public HttpResponseMessage Found()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DoesNotExist()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
        }
        
        public HttpResponseMessage AlreadyExists()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.Conflict);
        }
        
        // NOTE: I saw there was a BadRequest method in ApiController, but it returns a BadRequestResult.
        // I figured this was a better route for now.
        public HttpResponseMessage InvalidRequest(string errorMessage)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
        }
    }
}