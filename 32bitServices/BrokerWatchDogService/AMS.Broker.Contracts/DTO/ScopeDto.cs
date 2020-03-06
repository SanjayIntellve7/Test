using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class ScopeDto
    {
        [DataMember]
        public string Name { get; set; }
    }
}
