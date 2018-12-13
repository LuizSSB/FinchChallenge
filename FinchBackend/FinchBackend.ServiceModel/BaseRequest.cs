using ServiceStack;
using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel
{
    [DataContract]
    public abstract class BaseRequest : IHasSessionId, IReturn
    {
        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }
}
