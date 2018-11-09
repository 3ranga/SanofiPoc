using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sanofi.Sap.Requests;

namespace Sanofi.Sap.Domain.Test
{
    [TestClass]
    public class RequestServiceTest
    {
        [TestMethod]
        public void CreateDraftTest()
        {
            var requestRepo = new Mock<IRequestRepository>();
            requestRepo.Setup(r => r.Save(It.Is<Request>(e => e.Status == RequestStatus.Draft)));

            var requestService = new RequestService(requestRepo.Object);

            requestService.CreateDraft(new NewRequestContext { Request = new Request() });

            requestRepo.VerifyAll();
        }
    }
}
