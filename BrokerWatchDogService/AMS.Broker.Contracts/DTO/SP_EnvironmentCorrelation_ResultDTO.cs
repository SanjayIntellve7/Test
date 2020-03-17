using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_EnvironmentCorrelation_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Avg_Temp { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Avg_Humidity { get; set; }

        [DataMember()]
        public Nullable<Double> Env_AQI { get; set; }

        public SP_EnvironmentCorrelation_ResultDTO()
        {
        }

        public SP_EnvironmentCorrelation_ResultDTO(Nullable<DateTime> tXDate, Nullable<Double> env_Avg_Temp, Nullable<Double> env_Avg_Humidity, Nullable<Double> env_AQI)
        {
            this.TXDate = tXDate;
            this.Env_Avg_Temp = env_Avg_Temp;
            this.Env_Avg_Humidity = env_Avg_Humidity;
            this.Env_AQI = env_AQI;
        }
    }
}
