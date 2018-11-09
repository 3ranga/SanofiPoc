using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sanofi.Sap.Requests
{
    public class Request
    {
        public int Id { get; set; }
        public string Requester { get; set; }
        public string Message { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public enum RequestStatus
    {
        New = 0,
        Draft = 1,
        PendingApproval = 2,
        Approved = 3,
        Rejected = 4,
        OnHold = 5
    }

    public enum RequestTrigger
    {
        HcpDraft,
        RequestApproval,
        Approve,
        Reject,
        PutOnHold
    }
}
