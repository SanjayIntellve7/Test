using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblDisasterMapDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String RescueType { get; set; }

        [DataMember()]
        public Nullable<Double> lon { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public Nullable<Double> Deg { get; set; }

        public tblDisasterMapDTO()
        {
        }

        public tblDisasterMapDTO(Int32 iD, String rescueType, Nullable<Double> lon, String lat, Nullable<Double> deg)
        {
            this.ID = iD;
            this.RescueType = rescueType;
            this.lon = lon;
            this.Lat = lat;
            this.Deg = deg;
        }
    }
}

