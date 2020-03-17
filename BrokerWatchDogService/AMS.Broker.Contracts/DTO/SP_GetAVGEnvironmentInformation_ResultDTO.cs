using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetAVGEnvironmentInformation_ResultDTO
    {
        [DataMember()]
        public Nullable<Double> NO2 { get; set; }

        [DataMember()]
        public Nullable<Double> CO { get; set; }

        [DataMember()]
        public Nullable<Double> O3 { get; set; }

        [DataMember()]
        public Nullable<Double> SO2 { get; set; }

        [DataMember()]
        public Nullable<Double> HUM { get; set; }

        [DataMember()]
        public Nullable<Double> PM25 { get; set; }

        [DataMember()]
        public Nullable<Double> PM10 { get; set; }

        [DataMember()]
        public Nullable<Double> Temp { get; set; }

        [DataMember()]
        public Nullable<Double> NO { get; set; }

        [DataMember()]
        public Nullable<Double> AQI { get; set; }

        public SP_GetAVGEnvironmentInformation_ResultDTO()
        {
        }

        public SP_GetAVGEnvironmentInformation_ResultDTO(Nullable<Double> nO2, Nullable<Double> cO, Nullable<Double> o3, Nullable<Double> sO2, Nullable<Double> hUM, Nullable<Double> pM25, Nullable<Double> pM10, Nullable<Double> temp, Nullable<Double> nO, Nullable<Double> aQI)
        {
            this.NO2 = nO2;
            this.CO = cO;
            this.O3 = o3;
            this.SO2 = sO2;
            this.HUM = hUM;
            this.PM25 = pM25;
            this.PM10 = pM10;
            this.Temp = temp;
            this.NO = nO;
            this.AQI = aQI;
        }
    }
}
