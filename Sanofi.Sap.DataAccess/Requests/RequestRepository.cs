using System.Collections.Generic;
using System.Linq;
using Sanofi.Sap.Requests;

namespace Sanofi.Sap.DataAccess.Requests
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(SapDbContext dbContext) : base(dbContext)
        {
        }

        public Request GetRequest(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<Request> GetRequests()
        {
            return DbSet.AsNoTracking().ToList();
        }
    }
}
