using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetHotlistStatusCountDto
    {
        [DataMember()]
        public Nullable<Int32> ZoneCount { get; set; }

        [DataMember()]
        public Nullable<Int32> TotalIncidence { get; set; }

        [DataMember()]
        public Nullable<Int32> LMV { get; set; }

        [DataMember()]
        public Nullable<Int32> HMV { get; set; }

        public SP_GetHotlistStatusCountDto()
        {
        }

        public SP_GetHotlistStatusCountDto(Nullable<Int32> zoneCount, Nullable<Int32> totalIncidence, Nullable<Int32> lMV, Nullable<Int32> hMV)
        {
            this.ZoneCount = zoneCount;
            this.TotalIncidence = totalIncidence;
            this.LMV = lMV;
            this.HMV = hMV;
        }
    }
}
