using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public class tblIDSPanelSIMDetailsDTO
    {
        [DataMember()]
        public int ID { get; set; }
        [DataMember()]
        public int? DeviceID { get; set; }
        [DataMember()]
        public string SIMNumber { get; set; }
        [DataMember()]
        public string MDNNumber { get; set; }
        [DataMember()]
        public string IPaddress { get; set; }
        [DataMember()]
        public int? PanelMode { get; set; }
    }
}
