using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMBinMaster_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TotalCount { get; set; }

        [DataMember()]
        public Nullable<Double> Capacity { get; set; }

        public SP_SWMBinMaster_ResultDTO()
        {
        }

        public SP_SWMBinMaster_ResultDTO(Nullable<Int32> totalCount, Nullable<Double> capacity)
        {
            this.TotalCount = totalCount;
            this.Capacity = capacity;
        }
    }
}
