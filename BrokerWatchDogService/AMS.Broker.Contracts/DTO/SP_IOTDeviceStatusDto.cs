using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_IOTDeviceStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Int32 DeviceStatus { get; set; }

        public SP_IOTDeviceStatus_ResultDTO()
        {
        }

        public SP_IOTDeviceStatus_ResultDTO(Nullable<Int32> hour, Int32 deviceStatus)
        {
            this.Hour = hour;
            this.DeviceStatus = deviceStatus;
        }
    }
}
