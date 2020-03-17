using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class SP_GetHotlistMapDto
    {
        [DataMember()]
        public Nullable<Int32> HotlistIncidentcount { get; set; }

        [DataMember()]
        public String EqpID { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String HotListCatName { get; set; }

        [DataMember()]
        public String VehCatName { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Long_ { get; set; }

        [DataMember()]
        public Int32 AlertStatus { get; set; }

        [DataMember()]
        public String Status { get; set; }

        public SP_GetHotlistMapDto()
        {
        }

        public SP_GetHotlistMapDto(Nullable<Int32> hotlistIncidentcount, String eqpID, String zoneName, String junctionName, String hotListCatName, String vehCatName, String lat, String long_, Int32 alertStatus, String status)
        {
            this.HotlistIncidentcount = hotlistIncidentcount;
            this.EqpID = eqpID;
            this.ZoneName = zoneName;
            this.JunctionName = junctionName;
            this.HotListCatName = hotListCatName;
            this.VehCatName = vehCatName;
            this.Lat = lat;
            this.Long_ = long_;
            this.AlertStatus = alertStatus;
            this.Status = status;

        }
    }
}
