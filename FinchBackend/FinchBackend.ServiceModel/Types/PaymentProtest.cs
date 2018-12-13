using ServiceStack.DataAnnotations;
using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel.Types
{
    [DataContract]
    public class PaymentProtest : BaseEntity
    {
        [Required]
        [Index(Unique = true)]
        [DataMember(Name = "internalId")]
        public long InternalId { get; set; }

        [ForeignKey(typeof(Payment), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        [References(typeof(Payment))]
        [DataMember(Name = "paymentTitleNumber")]
        public long PaymentTitleNumber { get; set; }

        [Required]
        [Reference]
        [DataMember(Name = "payment")]
        public Payment Payment { get; set; }

        [Required]
        [DataMember(Name = "value")]
        public double Value { get; set; }

    }
}
