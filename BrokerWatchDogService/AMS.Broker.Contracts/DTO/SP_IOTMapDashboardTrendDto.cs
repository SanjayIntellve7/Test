using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTMapDashboardTrend_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TXDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> Value { get; set; }

        public SP_IOTMapDashboardTrend_ResultDTO()
        {
        }

        public SP_IOTMapDashboardTrend_ResultDTO(Nullable<Int32> tXDateTime, Nullable<Int32> value)
        {
            this.TXDateTime = tXDateTime;
            this.Value = value;
        }
    }
}
