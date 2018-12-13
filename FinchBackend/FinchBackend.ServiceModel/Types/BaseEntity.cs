using System.Runtime.Serialization;

namespace FinchBackend.ServiceModel.Types
{
    [DataContract]
    public class BaseEntity 
    {
        [DataMember(Name = "ownerId")]
        public string OwnerId { get; set; }

        [DataMember(Name = "createdTimestamp")]
        public long? CreatedTimestamp { get; set; }

        [DataMember(Name = "updatedTimestamp")]
        public long? UpdatedTimestamp { get; set; }
    }
}
