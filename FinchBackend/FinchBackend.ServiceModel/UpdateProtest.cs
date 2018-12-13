using ServiceStack;
using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel
{
    [DataContract]
    [Route("/protests/update")]
    public class UpdateProtest : BaseRequest
    {
        [DataMember(Name = "protest")]
        public Types.PaymentProtest Protest { get; set; }

        [DataMember(Name = "updatesReferences")]
        public bool UpdatesReferences { get; set; }
    }

    [DataContract]
    [Route("/payment")]
    public class UpdatePayment : BaseRequest
    {
        [DataMember(Name = "payment")]
        public Types.Payment Payment { get; set; }
    }

    [DataContract]
    [Route("/debtor")]
    public class UpdateDebtor : BaseRequest
    {
        [DataMember(Name = "debtor")]
        public Types.Debtor Debtor { get; set; }
    }
}
