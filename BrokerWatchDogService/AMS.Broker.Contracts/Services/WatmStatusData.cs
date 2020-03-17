using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class WatmStatusData
    {
        public List<WatmStatus> WatmStatus { get; set; }
    }

    public class WatmStatus
    {
        public string DeviceId { get; set; }
        public string Status { get; set; }
        public string UpdatedTime { get; set; }
    }
   
}
