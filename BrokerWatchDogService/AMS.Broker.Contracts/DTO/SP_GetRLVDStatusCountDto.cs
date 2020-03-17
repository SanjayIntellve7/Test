using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetRLVDStatusCountDto
    {
        [DataMember()]
        public Nullable<Int32> Count { get; set; }

        [DataMember()]
        public Nullable<Int32> label { get; set; }

        public SP_GetRLVDStatusCountDto()
        {
        }

        public SP_GetRLVDStatusCountDto(Nullable<Int32> count, Nullable<Int32> label)
        {
            this.Count = count;
            this.label = label;
        }
    }
}
