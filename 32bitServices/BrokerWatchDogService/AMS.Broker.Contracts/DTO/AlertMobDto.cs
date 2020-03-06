using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(ContactDto)), KnownType(typeof(SiteDto)), Serializable]
    public class AlertMobDto
    {
        [DataMember]
        public Alert Alert { get; set; }

        [DataMember]
        public string Status { get; set; }
        
        [DataMember]
        public string Severity { get; set; }

        [DataMember]
        public string Urgency { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string MessageTypeString { get; set; }

        [DataMember]
        public string AlertTime { get; set; }

        [DataMember]
        public string PlayBackStartTime { get; set; }

        [DataMember]
        public string PlayBackStopTime { get; set; }
        
        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public SiteDto Site { get; set; }
        [DataMember]
        public string MsiteName { get; set; }
        [DataMember]
        public string MfloorName { get; set; }
        [DataMember]
        public string MzoneName { get; set; }

        [DataMember]
        public ContactDto Contact{ get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }
    }
}
