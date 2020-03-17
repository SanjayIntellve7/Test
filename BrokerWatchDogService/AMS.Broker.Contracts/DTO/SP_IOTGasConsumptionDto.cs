using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTGasConsumption_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<Int32> GasConsumption { get; set; }

        public SP_IOTGasConsumption_ResultDTO()
        {
        }

        public SP_IOTGasConsumption_ResultDTO(Nullable<Int32> hour, Nullable<Int32> gasConsumption)
        {
            this.Hour = hour;
            this.GasConsumption = gasConsumption;
        }
    }
}
