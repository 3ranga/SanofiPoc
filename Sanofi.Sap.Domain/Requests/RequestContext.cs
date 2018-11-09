namespace Sanofi.Sap.Requests
{
    public abstract class RequestContext
    {
        public Request Request { get; set; }
    }

    public class NewRequestContext : RequestContext
    {

    }

    public class ApproveRequestContext : RequestContext
    {
        
    }

    public class RejectRequestContext : RequestContext
    {

    }

    public class RequestApprovalContext : RequestContext
    {

    }
}
