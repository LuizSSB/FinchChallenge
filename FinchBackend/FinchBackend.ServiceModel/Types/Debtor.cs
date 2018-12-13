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
    public class Debtor
    {
        [Required]
        [Index(Unique = true)]
        [DataMember(Name = "document")]
        public string Document { get; set; }
        
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "address")]
        public string Address { get; set; }

        [Required]
        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; set; }

        [Required]
        [DataMember(Name = "city")]
        public string City { get; set; }

        [Required]
        [DataMember(Name = "zipcode")]
        public string ZipCode { get; set; }

        [Required]
        [DataMember(Name = "stateCode")]
        public string StateCode { get; set; }
    }
}
