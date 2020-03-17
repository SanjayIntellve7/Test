using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_EnvKPI_ResultDTO
    {
        [DataMember()]
        public Nullable<Double> MaxTemp { get; set; }

        [DataMember()]
        public String MaxTempEqpName { get; set; }

        [DataMember()]
        public Nullable<Double> MinTemp { get; set; }

        [DataMember()]
        public String MinTempEqpName { get; set; }

        [DataMember()]
        public Nullable<Double> MaxHumidity { get; set; }

        [DataMember()]
        public String MaxHumidityEqpName { get; set; }

        [DataMember()]
        public Nullable<Double> MinHumidity { get; set; }

        [DataMember()]
        public String MinHumidityEqpName { get; set; }

        [DataMember()]
        public Nullable<Double> MaxAQI { get; set; }

        [DataMember()]
        public String MaxAQIEqpName { get; set; }

        [DataMember()]
        public Nullable<Double> MinAQI { get; set; }

        [DataMember()]
        public String MinAQIEqpName { get; set; }

        public SP_EnvKPI_ResultDTO()
        {
        }

        public SP_EnvKPI_ResultDTO(Nullable<Double> maxTemp, String maxTempEqpName, Nullable<Double> minTemp, String minTempEqpName, Nullable<Double> maxHumidity, String maxHumidityEqpName, Nullable<Double> minHumidity, String minHumidityEqpName, Nullable<Double> maxAQI, String maxAQIEqpName, Nullable<Double> minAQI, String minAQIEqpName)
        {
            this.MaxTemp = maxTemp;
            this.MaxTempEqpName = maxTempEqpName;
            this.MinTemp = minTemp;
            this.MinTempEqpName = minTempEqpName;
            this.MaxHumidity = maxHumidity;
            this.MaxHumidityEqpName = maxHumidityEqpName;
            this.MinHumidity = minHumidity;
            this.MinHumidityEqpName = minHumidityEqpName;
            this.MaxAQI = maxAQI;
            this.MaxAQIEqpName = maxAQIEqpName;
            this.MinAQI = minAQI;
            this.MinAQIEqpName = minAQIEqpName;
        }
    }
}
