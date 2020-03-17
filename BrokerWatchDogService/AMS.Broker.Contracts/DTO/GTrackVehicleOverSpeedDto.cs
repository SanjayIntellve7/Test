using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    
   // {"VehicleNo":"MH43X412","time":"","speed":"", "status": "false"}
    [DataContract()]
    public partial class GTrackVehicleOverSpeedDto
    {
        [DataMember()]
        public String VehicleNo { get; set; }

        [DataMember()]
        public String time { get; set; }

        [DataMember()]
        public String speed { get; set; }

        [DataMember()]
        public String status { get; set; }

        public GTrackVehicleOverSpeedDto()
        {
        }

        public GTrackVehicleOverSpeedDto(String vehicleNo, String time, String speed, String status)
        {
            this.VehicleNo = vehicleNo;
            this.time = time;
            this.speed = speed;
            this.status = status;
        }
    }
}
