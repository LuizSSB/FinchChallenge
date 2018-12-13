using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceModel
{
    [Route("/protests/{InternalId}")]
    public class GetProtest : BaseRequest, IReturn<GetProtestResponse>
    {
        public long InternalId { get; set; }
    }

    [DataContract]
    public class GetProtestResponse
    {
        [DataMember(Name = "protest")]
        public Types.PaymentProtest Protest { get; set; }
    }
}
