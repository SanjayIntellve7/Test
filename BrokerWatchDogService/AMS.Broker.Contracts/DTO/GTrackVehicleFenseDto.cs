using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    
  //  {"PoiData":"","entrytime":"", "status": "false"} 
    [DataContract()]
    public partial class GTrackVehicleFenseDto
    {
        [DataMember()]
        public String PoiData { get; set; }

        [DataMember()]
        public String entrytime { get; set; }

        [DataMember()]
        public String exittime { get; set; }

        [DataMember()]
        public String status { get; set; }

           [DataMember()]
        public String geofencestatus { get; set; }


        public GTrackVehicleFenseDto()
        {
        }

        public GTrackVehicleFenseDto(String poiData, String entrytime, String exittime, String status, String geofencestatus)
        {
            this.PoiData = poiData;
            this.entrytime = entrytime;
            this.exittime = exittime;
            this.status = status;
            this.geofencestatus = geofencestatus;
        }
    }
}
