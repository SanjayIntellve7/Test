using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblSWMBinMasterDTO
    {       
        [DataMember]
        public string BinAddress { get; set; }
        [DataMember]
        public string BinColor { get; set; }
        [DataMember]
        public string BinID { get; set; }
        [DataMember]
        public string BinType { get; set; }
        [DataMember]
        public double? Capacity { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public double? Lat { get; set; }
        [DataMember]
        public double? Long_ { get; set; }
        [DataMember]
        public string RFID { get; set; }
        [DataMember]
        public string SensorID { get; set; }
        [DataMember]
        public List<int> tblSWMBinTXData_ID { get; set; }
        [DataMember]
        public int? Thresholdlimit { get; set; }
        [DataMember]
        public string WardNo { get; set; }
    }
}
