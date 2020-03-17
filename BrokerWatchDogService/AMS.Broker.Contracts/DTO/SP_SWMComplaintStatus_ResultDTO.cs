using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMComplaintStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> StatusCount { get; set; }

        [DataMember()]
        public String ComplaintStatus { get; set; }

        public SP_SWMComplaintStatus_ResultDTO()
        {
        }

        public SP_SWMComplaintStatus_ResultDTO(Nullable<Int32> statusCount, String complaintStatus)
        {
            this.StatusCount = statusCount;
            this.ComplaintStatus = complaintStatus;
        }
    }
}
