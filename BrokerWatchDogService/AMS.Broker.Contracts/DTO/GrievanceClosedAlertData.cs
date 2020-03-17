using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    
    [DataContract]
    public class GrievanceClosedAlertData
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string SupervisorID { get; set; }

        [DataMember]
        public string CloseDateTime { get; set; }

        [DataMember]
        public string Status { get; set; }

    }
}
