using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public partial class InterfaceTypeDto
    {
        [DataMember]
        public int InterfaceTypeId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
