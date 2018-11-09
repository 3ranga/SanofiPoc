using Sanofi.Sap.Requests;
using Sanofi.Sap.Web.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using Sanofi.Sap.Web.Util;

namespace Sanofi.Sap.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/requests")]
    [InvalidStateTransitionExceptionFilter]
    public class RequestsController : ApiController
    {
        private readonly IDomainContext _domainContext;
        private readonly RequestService _requestService;
        private readonly IRequestRepository _requestRepository;

        public RequestsController(IDomainContext domainContext, RequestService requestService, IRequestRepository requestRepository)
        {
            _domainContext = domainContext;
            _requestService = requestService;
            _requestRepository = requestRepository;
        }

        [HttpPost]
        public IHttpActionResult Draft(NewRequestModel newRequest)
        {
            using (_domainContext)
            {
                var requestContext = new NewRequestContext
                { Request = new Request { Message = newRequest.Message, Requester = newRequest.Requester } };
                var request = _requestService.CreateDraft(requestContext);

                _domainContext.SaveChanges();

                return Json(request);
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Index()
        {
            return Json(_requestRepository.GetRequests());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Index(int id)
        {
            return Json(_requestRepository.GetRequest(id));
        }

        [HttpPost]
        [Route("requestApproval")]
        public IHttpActionResult RequestApproal(RequestApprovalModel requestApprovalModel)
        {
            using (_domainContext)
            {
                var requestContext = new RequestApprovalContext { Request = new Request { Id = requestApprovalModel.Id } };
                var request = _requestService.RequestApproval(requestContext);

                _domainContext.SaveChanges();

                return Json(request);
            }
        }


        [HttpPost]
        [Route("approve")]
        public IHttpActionResult Approve(ApproveRequestModel approveRequestModel)
        {
            using (_domainContext)
            {
                var requestContext = new ApproveRequestContext { Request = new Request { Id = approveRequestModel.Id } };
                var request = _requestService.Approve(requestContext);

                _domainContext.SaveChanges();

                return Json(request);
            }
        }

        [HttpPost]
        [Route("reject")]
        public IHttpActionResult Reject(RejectRequestModel rejectRequestModel)
        {
            using (_domainContext)
            {
                var requestContext = new RejectRequestContext { Request = new Request { Id = rejectRequestModel.Id } };
                var request = _requestService.Reject(requestContext);

                _domainContext.SaveChanges();

                return Json(request);
            }            
        }
    }
}
