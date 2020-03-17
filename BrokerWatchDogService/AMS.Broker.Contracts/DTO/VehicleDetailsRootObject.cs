using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class VehicleDetailsRootObject
    {      
        public string Status { get; set; }
        public List<VehicleDetailDTO> vehicleDetails { get; set; }
    }

    public class VehicleDetailDTO
    {      

        public string altitude { get; set; }
        public string angle { get; set; }
        public string batteryStatus { get; set; }
        public string dateTime { get; set; }
        public string driverMobile { get; set; }
        public string driverName { get; set; }
        public string ignition { get; set; }
        public double latitude { get; set; }
        public string location { get; set; }
        public double longitude { get; set; }
        public string simNo { get; set; }
        public string speed { get; set; }
        public string status { get; set; }
        public string vehicleNo { get; set; }
        public string VehicleStatus { get; set; }
        public string vehicleType { get; set; }
        public string wardNo { get; set; }
    }
}
