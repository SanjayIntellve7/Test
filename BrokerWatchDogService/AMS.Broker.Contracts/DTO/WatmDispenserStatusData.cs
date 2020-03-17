using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    
    public class WatmDispenserStatusData
    {
        public List<WatmDispenserStatus> WatmDispenserStatus { get; set; }
    }

    public class WatmDispenserStatus
    {
        public string DeviceId { get; set; }
        public string DispenserId { get; set; }
        public string Status { get; set; }
        public string UpdatedTime { get; set; }
    }
}
