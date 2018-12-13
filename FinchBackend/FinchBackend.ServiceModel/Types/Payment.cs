using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceModel.Types
{
    [DataContract]
    public class Payment
    {
        [Index(Unique = true)]
        [DataMember(Name = "titleNumber")]
        public long TitleNumber { get; set; }

        [ForeignKey(typeof(Debtor), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        [References(typeof(Debtor))]
        [DataMember(Name = "debtorDocument")]
        public string DebtorDocument { get; set; }

        [Required]
        [Reference]
        [DataMember(Name = "debtor")]
        public Debtor Debtor { get; set; }

        [Required]
        [DataMember(Name = "bankId")]
        public long BankId { get; set; }

        [Required]
        [DataMember(Name = "creditorName")]
        public string CreditorName { get; set; }

        [Required]
        [DataMember(Name = "value")]
        public double Value { get; set; }

        [Required]
        [DataMember(Name = "emissionDateTimestamp")]
        public long EmissionDateTimestamp { get; set; }

        [Required]
        [DataMember(Name = "expirationDateTimestamp")]
        public long ExpirationDateTimestamp { get; set; }

        [DataMember(Name = "numberOfInstallments")]
        public int? NumberOfInstallments { get; set; }

        [DataMember(Name = "firstInstallmentValue")]
        public double? FirstInstallmentValue { get; set; }

        [Required]
        [DataMember(Name = "documentType")]
        public string DocumentType { get; set; }

        [Required]
        [DataMember(Name = "operation")]
        public string Operation { get; set; }

        [Required]
        [DataMember(Name = "city")]
        public string City { get; set; }

        [Required]
        [DataMember(Name = "stateCode")]
        public string StateCode { get; set; }
    }
}
