using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMWardComplaintStatusDetails_ResultDTO
    {
        [DataMember()]
        public Int64 AlertId { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        [DataMember()]
        public DateTime Sent { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String Status { get; set; }

        public SP_SWMWardComplaintStatusDetails_ResultDTO()
        {
        }

        public SP_SWMWardComplaintStatusDetails_ResultDTO(Int64 alertId, String messageTypeId, DateTime sent, String latitude, String longitude, String wardName, String wardNo, String status)
        {
            this.AlertId = alertId;
            this.MessageTypeId = messageTypeId;
            this.Sent = sent;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.WardName = wardName;
            this.WardNo = wardNo;
            this.Status = status;
        }
    }
}
