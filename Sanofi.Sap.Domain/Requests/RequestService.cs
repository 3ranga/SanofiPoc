using System;

namespace Sanofi.Sap.Requests
{
    public class RequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Request CreateDraft(NewRequestContext context)
        {
            var request = context.Request;
            var requestWorkflow = CreateRequestWorkflow(RequestStatus.New);

            requestWorkflow.TriggerWorkflow(RequestTrigger.HcpDraft);
            request.Status = requestWorkflow.Status;
            request.CreatedOn = DateTime.UtcNow;

            _requestRepository.Save(request);

            return request;
        }

        public Request Approve(ApproveRequestContext context)
        {
            var request = _requestRepository.GetRequest(context.Request.Id);
            var requestWorkflow = CreateRequestWorkflow(request.Status);

            requestWorkflow.TriggerWorkflow(RequestTrigger.Approve);
            request.Status = requestWorkflow.Status;
            request.UpdatedOn = DateTime.UtcNow;

            _requestRepository.Save(request);

            return request;
        }

        public Request Reject(RejectRequestContext context)
        {
            var request = _requestRepository.GetRequest(context.Request.Id);
            var requestWorkflow = CreateRequestWorkflow(request.Status);

            requestWorkflow.TriggerWorkflow(RequestTrigger.Reject);
            request.Status = requestWorkflow.Status;
            request.UpdatedOn = DateTime.UtcNow;

            _requestRepository.Save(request);

            return request;
        }

        public Request RequestApproval(RequestApprovalContext context)
        {
            var request = _requestRepository.GetRequest(context.Request.Id);
            var requestWorkflow = CreateRequestWorkflow(request.Status);

            requestWorkflow.TriggerWorkflow(RequestTrigger.RequestApproval);
            request.Status = requestWorkflow.Status;
            request.UpdatedOn = DateTime.UtcNow;

            _requestRepository.Save(request);

            return request;
        }

        private RequestWorkflow CreateRequestWorkflow(RequestStatus status)
        {
            return new RequestWorkflow(status);
        }
    }
}
