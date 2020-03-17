using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class WATMDispenserStatusDataDto
    {
        public string DeviceId { get; set; }
        public string DispenserId { get; set; }
        public string status { get; set; }
        public string UpdatedTime { get; set; }
    }
}
