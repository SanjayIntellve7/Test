using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_VMDStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<Int64> DeviceId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Long_ { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatus { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String DeviceStatusDesc { get; set; }

        public SP_VMDStatus_ResultDTO()
        {
        }

        public SP_VMDStatus_ResultDTO(Nullable<Int64> deviceId, String name, String externalId, String lat, String long_, String locationDescription, Nullable<Int32> deviceStatus, String junctionName, String wardName, String zoneName, String deviceStatusDesc)
        {
            this.DeviceId = deviceId;
            this.Name = name;
            this.ExternalId = externalId;
            this.Lat = lat;
            this.Long_ = long_;
            this.LocationDescription = locationDescription;
            this.DeviceStatus = deviceStatus;
            this.JunctionName = junctionName;
            this.WardName = wardName;
            this.ZoneName = zoneName;
            this.DeviceStatusDesc = deviceStatusDesc;
        }
    }
}
