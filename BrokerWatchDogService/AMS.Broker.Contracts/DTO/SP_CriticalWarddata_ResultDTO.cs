using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_CriticalWarddata_ResultDTO
    {
        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public Nullable<Int32> TotalBinsCrossedThreshold { get; set; }

        public SP_CriticalWarddata_ResultDTO()
        {
        }

        public SP_CriticalWarddata_ResultDTO(String wardNo, String wardName, Nullable<Int32> totalBinsCrossedThreshold)
        {
            this.WardNo = wardNo;
            this.WardName = wardName;
            this.TotalBinsCrossedThreshold = totalBinsCrossedThreshold;
        }
    }
}
