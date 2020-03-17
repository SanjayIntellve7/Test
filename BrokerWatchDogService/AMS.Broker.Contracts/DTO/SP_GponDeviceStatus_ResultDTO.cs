using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GponDeviceStatus_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public String OID { get; set; }

        [DataMember()]
        public String OIDStatus { get; set; }

        public SP_GponDeviceStatus_ResultDTO()
        {
        }

        public SP_GponDeviceStatus_ResultDTO(Int32 iD, Nullable<Int32> deviceID, String oID, String oIDStatus)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.OID = oID;
            this.OIDStatus = oIDStatus;
        }
    }
}
