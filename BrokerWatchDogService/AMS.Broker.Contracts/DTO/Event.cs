using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class Event
    {
        [DataMember]
        public string ItemId { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public string Adapter { get; set; }

    }
}
