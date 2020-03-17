using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class StationTypeDTO
    {
        [DataMember()]
        public String StationType1 { get; set; }

        [DataMember]
        public Int32 StationTypeID { get; set; }

        public StationTypeDTO()
        {
        }

        public StationTypeDTO(String stationType1, Int32 stationTypeID)
        {
            this.StationType1 = stationType1;
            this.StationTypeID = stationTypeID;
        }
    }
}
