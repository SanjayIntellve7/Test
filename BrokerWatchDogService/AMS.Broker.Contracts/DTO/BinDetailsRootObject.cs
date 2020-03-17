using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class BinDetailsRootObject
    {       

        public List<BinDetailDTO> binDetails { get; set; }
        public string Status { get; set; }
    }
    public class BinDetailDTO
    {       

        public string Address { get; set; }
        public string BinColor { get; set; }
        public string BinID { get; set; }
        public string BinType { get; set; }
        public string Capacity { get; set; }
        public string CleanedTime { get; set; }
        public string FilledLevel { get; set; }
        public string Latitude { get; set; }
        public string LoggedTime { get; set; }
        public string Longitude { get; set; }
        public string RFID { get; set; }
        public string SensorID { get; set; }
        public string ThresholdLimit { get; set; }
        public string VehicleNo { get; set; }
        public string WardNo { get; set; }
    }
}
