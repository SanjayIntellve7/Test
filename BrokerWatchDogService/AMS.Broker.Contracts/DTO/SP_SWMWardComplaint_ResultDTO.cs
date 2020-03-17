using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMWardComplaint_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> ComplaintCount { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public String Status { get; set; }

        public SP_SWMWardComplaint_ResultDTO()
        {
        }

        public SP_SWMWardComplaint_ResultDTO(Nullable<Int32> complaintCount, String wardNo, String wardName, String latitude, String longitude, String status)
        {
            this.ComplaintCount = complaintCount;
            this.WardNo = wardNo;
            this.WardName = wardName;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Status = status;
        }
    }
}
