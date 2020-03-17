using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTEnergyConsumption_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<Int32> EnergyConsumption { get; set; }

        public SP_IOTEnergyConsumption_ResultDTO()
        {
        }

        public SP_IOTEnergyConsumption_ResultDTO(Nullable<Int32> hour, Nullable<Int32> energyConsumption)
        {
            this.Hour = hour;
            this.EnergyConsumption = energyConsumption;
        }
    }
}
