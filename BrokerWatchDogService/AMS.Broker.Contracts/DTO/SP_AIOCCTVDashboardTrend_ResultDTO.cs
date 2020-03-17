using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_AIOCCTVDashboardTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<DateTime> Tempdate { get; set; }

        [DataMember()]
        public Nullable<Int32> HourCount { get; set; }

        public SP_AIOCCTVDashboardTrend_ResultDTO()
        {
        }

        public SP_AIOCCTVDashboardTrend_ResultDTO(Nullable<Int32> hour, Nullable<DateTime> tempdate, Nullable<Int32> hourCount)
        {
            this.Hour = hour;
            this.Tempdate = tempdate;
            this.HourCount = hourCount;
        }
    }
}
