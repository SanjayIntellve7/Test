using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMWardAttendence_ResultDto
    {
        [DataMember()]
        public Nullable<Int32> AttendenceCount { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public String TotalCount { get; set; }

        public SP_SWMWardAttendence_ResultDto()
        {
        }

        public SP_SWMWardAttendence_ResultDto(Nullable<Int32> attendenceCount, String wardNo, String wardName, String latitude, String longitude, String totalCount)
        {
            this.AttendenceCount = attendenceCount;
            this.WardNo = wardNo;
            this.WardName = wardName;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.TotalCount = totalCount;
        }
    }
}
