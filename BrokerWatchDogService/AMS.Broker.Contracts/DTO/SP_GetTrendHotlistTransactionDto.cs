using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetTrendHotlistTransactionDto
    {
        [DataMember()]
        public Nullable<Int32> HotlistCount { get; set; }

        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        public SP_GetTrendHotlistTransactionDto()
        {
        }

        public SP_GetTrendHotlistTransactionDto(Nullable<Int32> hotlistCount, Nullable<Int32> hour)
        {
            this.HotlistCount = hotlistCount;
            this.Hour = hour;
        }
    }
}
