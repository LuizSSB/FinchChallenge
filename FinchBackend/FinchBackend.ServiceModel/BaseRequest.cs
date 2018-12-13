using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceModel
{
    [DataContract]
    public class BaseRequest : IHasSessionId, IReturn
    {
        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }
}
