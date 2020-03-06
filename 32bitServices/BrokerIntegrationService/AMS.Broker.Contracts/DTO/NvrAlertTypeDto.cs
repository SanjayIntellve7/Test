using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class NvrAlertTypeDto
    {
        [DataMember]
        public int NvrAlertTypeId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
