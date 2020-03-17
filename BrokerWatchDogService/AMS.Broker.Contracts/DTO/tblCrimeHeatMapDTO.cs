using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblCrimeHeatMapDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Crime { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public Nullable<Double> lon { get; set; }

        [DataMember()]
        public Nullable<Double> Deg { get; set; }

        public tblCrimeHeatMapDTO()
        {
        }

        public tblCrimeHeatMapDTO(Int32 iD, String crime, String lat, Nullable<Double> lon, Nullable<Double> deg)
        {
            this.ID = iD;
            this.Crime = crime;
            this.Lat = lat;
            this.lon = lon;
            this.Deg = deg;
        }
    }
}
