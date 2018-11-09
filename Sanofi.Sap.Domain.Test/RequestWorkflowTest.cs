using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanofi.Sap.Requests;

namespace Sanofi.Sap.Domain.Test
{
    [TestClass]
    public class RequestWorkflowTest
    {
        [TestMethod]
        public void AllowedTransitions()
        {
            ExecuteFlow(RequestStatus.New, RequestTrigger.HcpDraft, RequestStatus.Draft);
            ExecuteFlow(RequestStatus.Draft, RequestTrigger.RequestApproval, RequestStatus.PendingApproval);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void InvalidTransitions()
        {
            ExecuteFlow(RequestStatus.Draft, RequestTrigger.Approve, RequestStatus.Approved);
        }

        private static void ExecuteFlow(RequestStatus initial, RequestTrigger trigger, RequestStatus expectedEndStatus)
        {
            var workflow = new RequestWorkflow(initial);

            workflow.TriggerWorkflow(trigger);

            Assert.AreEqual(expectedEndStatus, workflow.Status);
        }
    }
}
