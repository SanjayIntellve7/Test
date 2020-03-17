using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ComplaintHourly_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<Int32> ComplaintCount { get; set; }

        public SP_ComplaintHourly_ResultDTO()
        {
        }

        public SP_ComplaintHourly_ResultDTO(Nullable<Int32> hour, Nullable<Int32> complaintCount)
        {
            this.Hour = hour;
            this.ComplaintCount = complaintCount;
        }
    }
}
