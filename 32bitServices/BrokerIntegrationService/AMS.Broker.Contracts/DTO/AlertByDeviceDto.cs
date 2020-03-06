using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AlertByDeviceDto
    {
        [DataMember]
        public Int64 AlertId { get; set; }

        [DataMember]
        public DateTime Sent { get; set; }

        [DataMember]
        public Severity Severity { get; set; }

        [DataMember]
        public MessageType MessageTypeId { get; set; }
        [DataMember]
        public string AlertDate { get; set; }
        [DataMember]
        public string AlertTime { get; set; }
    }
}
