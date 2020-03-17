using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetRLVDStatusMapDto
    {
        [DataMember()]
        public Nullable<Int32> RLVDIncidentcount { get; set; }

        [DataMember()]
        public String EqpID { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String ViolationName { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Long_ { get; set; }

        [DataMember()]
        public Int32 AlertStatus { get; set; }

        [DataMember()]
        public String Status { get; set; }

        public SP_GetRLVDStatusMapDto()
        {
        }

        public SP_GetRLVDStatusMapDto(Nullable<Int32> rLVDIncidentcount, String eqpID, String zoneName, String junctionName, String violationName, String lat, String long_, Int32 alertStatus, String status)
        {
            this.RLVDIncidentcount = rLVDIncidentcount;
            this.EqpID = eqpID;
            this.ZoneName = zoneName;
            this.JunctionName = junctionName;
            this.ViolationName = violationName;
            this.Lat = lat;
            this.Long_ = long_;
            this.AlertStatus = alertStatus;
            this.Status = status;
        }
    }
}
