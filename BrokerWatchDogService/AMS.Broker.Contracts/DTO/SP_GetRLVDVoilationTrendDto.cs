using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetRLVDVoilationTrendDto
    {
        [DataMember()]
        public Nullable<Int32> ViolationCount { get; set; }

        [DataMember()]
        public Nullable<Int32> Day { get; set; }

        public SP_GetRLVDVoilationTrendDto()
        {
        }

        public SP_GetRLVDVoilationTrendDto(Nullable<Int32> violationCount, Nullable<Int32> day)
        {
            this.ViolationCount = violationCount;
            this.Day = day;
        }
    }
}
