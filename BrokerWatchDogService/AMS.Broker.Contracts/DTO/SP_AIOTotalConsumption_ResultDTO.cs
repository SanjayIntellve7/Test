using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_AIOTotalConsumption_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<DateTime> Tempdate { get; set; }

        [DataMember()]
        public Nullable<Double> TotalCOnsumption { get; set; }

        public SP_AIOTotalConsumption_ResultDTO()
        {
        }

        public SP_AIOTotalConsumption_ResultDTO(Nullable<Int32> hour, Nullable<DateTime> tempdate, Nullable<Double> totalCOnsumption)
        {
            this.Hour = hour;
            this.Tempdate = tempdate;
            this.TotalCOnsumption = totalCOnsumption;
        }
    }
}
