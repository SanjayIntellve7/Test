using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPrimarySecondaryCamGuidMappingDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String PrimaryDeviceGuid { get; set; }

        [DataMember()]
        public String PrimaryDeviceIP { get; set; }//public Nullable<Int64> PrimaryDeviceID { get; set; }

        [DataMember()]
        public String PrimaryDeviceName { get; set; }

        [DataMember()]
        public String SecondaryDeviceGuid { get; set; }

        [DataMember()]
        public String SecondaryDeviceIP { get; set; }//public Nullable<Int64> SecondaryDeviceID { get; set; }

        [DataMember()]
        public String SecondaryDeviceName { get; set; }

        public tblPrimarySecondaryCamGuidMappingDTO()
        {
        }

        public tblPrimarySecondaryCamGuidMappingDTO(Int64 iD, String primaryDeviceGuid, String primaryDeviceIP, String PrimaryDeviceName, String secondaryDeviceGuid, String secondaryDeviceIP, String SecondaryDeviceName)
        {
            this.ID = iD;
            this.PrimaryDeviceGuid = primaryDeviceGuid;
            this.PrimaryDeviceIP = primaryDeviceIP;
            this.SecondaryDeviceGuid = secondaryDeviceGuid;
            this.SecondaryDeviceIP = secondaryDeviceIP;
            this.PrimaryDeviceName = PrimaryDeviceName;
            this.SecondaryDeviceName = SecondaryDeviceName;
        }
    }
}
