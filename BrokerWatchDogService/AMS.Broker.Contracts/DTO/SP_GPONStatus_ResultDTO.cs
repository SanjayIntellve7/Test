using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GPONStatus_ResultDTO
    {
        [DataMember()]
        public Int64 DeviceID { get; set; }

        [DataMember()]
        public String DeviceExternal { get; set; }

        [DataMember()]
        public String DeviceStatus { get; set; }

        [DataMember()]
        public String PortNo { get; set; }

        [DataMember()]
        public String Entity { get; set; }

        public SP_GPONStatus_ResultDTO()
        {
        }

        public SP_GPONStatus_ResultDTO(Int64 deviceID, String deviceExternal, String deviceStatus, String portNo, String entity)
        {
            this.DeviceID = deviceID;
            this.DeviceExternal = deviceExternal;
            this.DeviceStatus = deviceStatus;
            this.PortNo = portNo;
            this.Entity = entity;
        }
    }
}
