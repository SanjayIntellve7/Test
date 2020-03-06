using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class AnprStatusDto
    {
        [DataMember()]
        public String LPID { get; set; }

        [DataMember()]
        public String LPUName { get; set; }

        [DataMember()]
        public String LPUStatus { get; set; }

        [DataMember()]
        public String ANprDeviceID { get; set; }

        [DataMember()]
        public String DeviceStatus { get; set; }

        [DataMember()]
        public String DeviceID { get; set; }

        [DataMember()]
        public String AnprDevName { get; set; }

        public AnprStatusDto()
        {
        }

        public AnprStatusDto(String lPID, String lPUName, String lPUStatus, String aNprDeviceID, String deviceStatus, String deviceID, String anprDevName)
        {
            this.LPID = lPID;
            this.LPUName = lPUName;
            this.LPUStatus = lPUStatus;
            this.ANprDeviceID = aNprDeviceID;
            this.DeviceStatus = deviceStatus;
            this.DeviceID = deviceID;
            this.AnprDevName = anprDevName;
        }

    }
}