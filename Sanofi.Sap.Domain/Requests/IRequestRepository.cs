using System.Collections.Generic;

namespace Sanofi.Sap.Requests
{
    public interface IRequestRepository : IRepository<Request>
    {
        Request GetRequest(int id);

        IEnumerable<Request> GetRequests();
    }
}
