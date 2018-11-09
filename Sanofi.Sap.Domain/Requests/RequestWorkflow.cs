using System;
using Stateless;

namespace Sanofi.Sap.Requests
{
    public class RequestWorkflow
    {
        private readonly StateMachine<RequestStatus, RequestTrigger> _requestFlow;

        public RequestWorkflow(RequestStatus status)
        {
            _requestFlow = new StateMachine<RequestStatus, RequestTrigger>(status);

            _requestFlow.Configure(RequestStatus.PendingApproval)
                .Permit(RequestTrigger.Approve, RequestStatus.Approved)
                .Permit(RequestTrigger.Reject, RequestStatus.Rejected)
                .Permit(RequestTrigger.PutOnHold, RequestStatus.OnHold)
                .OnExit(ExitAction);
            _requestFlow.Configure(RequestStatus.Draft)
                .Permit(RequestTrigger.RequestApproval, RequestStatus.PendingApproval);
            _requestFlow.Configure(RequestStatus.OnHold)
                .Permit(RequestTrigger.RequestApproval, RequestStatus.PendingApproval);
            _requestFlow.Configure(RequestStatus.New)
                .Permit(RequestTrigger.HcpDraft, RequestStatus.Draft);
        }

        private void ExitAction(StateMachine<RequestStatus, RequestTrigger>.Transition transition)
        {
            
        }

        public void TriggerWorkflow(RequestTrigger trigger)
        {
            try
            {
                _requestFlow.Fire(trigger);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidStateTransitionException("This state transition is not allowed", e);
            }
        }

        public RequestStatus Status => _requestFlow.State;
    }
}
