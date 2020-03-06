using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class DeviceTypeDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}
