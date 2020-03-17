using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SWMVehicleLastTxnDetailsDto
    {      
        public long DeviceId { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public DateTime? TxnDateTime { get; set; }
        public string VehicleNo { get; set; }
        public string WardNo { get; set; }
    }
}
