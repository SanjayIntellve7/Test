using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblSWMBinTXDataDTO
    {       
        [DataMember]
        public long? AlertID { get; set; }
        [DataMember]
        public int? BinMasterID { get; set; }
        [DataMember]
        public DateTime? CleanedDateTime { get; set; }
        [DataMember]
        public int? FilledLevel { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int tblSWMBinMaster_ID { get; set; }
        [DataMember]
        public DateTime? TXDataTime { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
    }
}
