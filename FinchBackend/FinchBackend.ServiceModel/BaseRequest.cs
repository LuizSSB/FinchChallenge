using ServiceStack;
using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel
{
    [DataContract]
    public class BaseRequest : IHasSessionId, IReturn
    {
        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }
}
