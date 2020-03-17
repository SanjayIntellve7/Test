using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetRLVDEquipmentStatusCountDto
    {
        [DataMember()]
        public Nullable<Int32> StatusCount { get; set; }

        [DataMember()]
        public String Status { get; set; }

        public SP_GetRLVDEquipmentStatusCountDto()
        {
        }

        public SP_GetRLVDEquipmentStatusCountDto(Nullable<Int32> statusCount, String status)
        {
            this.StatusCount = statusCount;
            this.Status = status;
        }
    }
}
