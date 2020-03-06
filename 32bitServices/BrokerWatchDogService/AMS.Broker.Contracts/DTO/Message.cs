using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class Message
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public int MonitorId { get; set; }
        [DataMember]
        public string StationName { get; set; }
    }
}
