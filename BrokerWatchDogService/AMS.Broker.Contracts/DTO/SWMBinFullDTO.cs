using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SWMBinFullDTO
    { 
        [DataMember]
        public string BinID { get; set; }
        [DataMember]
        public string Capacity { get; set; }
        [DataMember]
        public string FillPercent { get; set; }
        [DataMember]
        public string LastCleanedDateTime { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string LogDateTime { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string RFIDTag { get; set; }
        [DataMember]
        public string SensorId { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Ward { get; set; }
    }
}
