using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMWardComplaintStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<int> ComplaintStatus { get; set; }

        [DataMember()]
        public string Status { get; set; }
    }
}
