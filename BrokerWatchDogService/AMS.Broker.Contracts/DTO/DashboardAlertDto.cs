using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class DashboardAlertDto
    {
        public Int64 AlertId { get; set; }
        public DateTime? Sent { get; set; }
        public string MessageTypeId { get; set; }
        public string Code { get; set; }
        public long? DeviceId { get; set; }
        public string Severity { get; set; }
        public DateTime? ReceivedDateTime { get; set; }
        public string DeviceType { get; set; }
    }
}
