using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_PasStatus_ResultDTO
    {
        [DataMember()]
        public Nullable<Int64> DeviceId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatus { get; set; }

        [DataMember()]
        public String DeviceStatusDesc { get; set; }

        public SP_PasStatus_ResultDTO()
        {
        }

        public SP_PasStatus_ResultDTO(Nullable<Int64> deviceId, String name, String externalId, Double lat, Double long_, String locationDescription, Nullable<Int32> deviceStatus, String deviceStatusDesc)
        {
            this.DeviceId = deviceId;
            this.Name = name;
            this.ExternalId = externalId;
            this.Lat = lat;
            this.Long_ = long_;
            this.LocationDescription = locationDescription;
            this.DeviceStatus = deviceStatus;
            this.DeviceStatusDesc = deviceStatusDesc;
        }
    }
}
