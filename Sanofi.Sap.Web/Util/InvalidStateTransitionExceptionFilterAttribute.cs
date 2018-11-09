using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Sanofi.Sap.Web.Util
{
    public class InvalidStateTransitionExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is InvalidStateTransitionException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Invalid State Transition Request"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}