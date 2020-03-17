using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class DeviceDetailsWithStatusDTO
    {        
        [DataMember()]
        public long DeviceID { get; set; }

        [DataMember()]
        public string DeviceName { get; set; }

        [DataMember()]
        public String DeviceExternalId { get; set; }

        [DataMember()]
        public String DeviceDescription { get; set; }

        [DataMember()]
        public Double DeviceLat { get; set; }

        [DataMember()]
        public Double DeviceLong { get; set; }

        [DataMember()]
        public String DeviceLocation { get; set; }

        [DataMember()]
        public bool DeviceActiveAlert { get; set; }

        [DataMember()]
        public long DeviceStatusID { get; set; }

        [DataMember()]
        public String DeviceStatusType { get; set; }

        [DataMember()]
        public DateTime? DeviceStatusDateTime { get; set; }

        [DataMember()]
        public int? DeviceStatus { get; set; }

        [DataMember()]
        public String DeviceStatusDesc { get; set; }      

    }
}
