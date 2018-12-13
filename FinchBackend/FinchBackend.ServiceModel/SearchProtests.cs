using ServiceStack;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel
{
    [Route("/protests")]
    [DataContract]
    public class SearchProtests : BaseRequest, IReturn<SearchProtestsResponse>
    {
        [DataMember(Name = "minValue")]
        public double? MinimumProtestValue { get; set; }

        [DataMember(Name = "maxValue")]
        public double? MaximumProtestValue { get; set; }

        [DataMember(Name = "offset")]
        public int? Offset { get; set; }

        [DataMember(Name = "limit")]
        public int? Limit { get; set; }

        [DataMember(Name = "bank")]
        public long? BankId { get; set; }

        [DataMember(Name = "debtor")]
        public string DebtorName { get; set; }
    }

    [DataContract]
    public class SearchProtestsResponse
    {
        [DataMember(Name = "protests")]
        public List<Types.PaymentProtest> Protests { get; set; }
    }
}
