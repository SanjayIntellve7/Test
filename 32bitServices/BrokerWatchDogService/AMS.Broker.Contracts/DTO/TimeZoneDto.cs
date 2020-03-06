using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class TimeZoneDto
    {
        [DataMember]
        public int TimeZoneId { get; set; }
        [DataMember]
        public string Abbreviation { get; set; }
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Shift { get; set; }
    }
}
