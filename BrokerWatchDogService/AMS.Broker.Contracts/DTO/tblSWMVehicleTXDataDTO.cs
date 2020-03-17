using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblSWMVehicleTXDataDTO
    {             
        [DataMember]
        public long? AlertID { get; set; }
        [DataMember]
        public double? Altitude { get; set; }
        [DataMember]
        public double? Angle { get; set; }
        [DataMember]
        public string BatteryStatus { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Ignition { get; set; }
        [DataMember]
        public double? Lat { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public double? Long_ { get; set; }
        [DataMember]
        public int? Speed { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int tblSWMVehicleMaster_ID { get; set; }
        [DataMember]
        public DateTime? TXDataTime { get; set; }
        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public string VehicleStatus { get; set; }
    }
}
