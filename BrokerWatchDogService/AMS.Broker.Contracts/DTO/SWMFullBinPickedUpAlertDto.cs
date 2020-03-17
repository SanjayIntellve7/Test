using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SWMFullBinPickedUpAlertDto
    {

        [DataMember]
        public string BinID { get; set; }
        [DataMember]
        public string CleanedDateTime { get; set; }
        [DataMember]
        public string FillPercent { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
    }
}
