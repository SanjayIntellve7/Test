using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTWaterConsumption_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<Int32> WaterConsumption { get; set; }

        public SP_IOTWaterConsumption_ResultDTO()
        {
        }

        public SP_IOTWaterConsumption_ResultDTO(Nullable<Int32> hour, Nullable<Int32> waterConsumption)
        {
            this.Hour = hour;
            this.WaterConsumption = waterConsumption;
        }
    }
}
