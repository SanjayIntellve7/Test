using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetHotlistTransactionDto
    {
        [DataMember()]
        public Nullable<Int32> HotlistCount { get; set; }

        [DataMember()]
        public String HotlistCatName { get; set; }

        public SP_GetHotlistTransactionDto()
        {
        }

        public SP_GetHotlistTransactionDto(Nullable<Int32> hotlistCount, String hotlistCatName)
        {
            this.HotlistCount = hotlistCount;
            this.HotlistCatName = hotlistCatName;
        }
    }
}
