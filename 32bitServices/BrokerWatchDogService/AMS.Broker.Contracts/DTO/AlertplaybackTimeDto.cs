using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AlertplaybackTimeDto
    {
        [DataMember]
        public string playbackStartTime { get; set; }

        [DataMember]
        public string playbackEndTime { get; set; }
    }
}