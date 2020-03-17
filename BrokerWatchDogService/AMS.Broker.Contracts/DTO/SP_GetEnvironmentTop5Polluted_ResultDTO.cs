using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetEnvironmentTop5Polluted_ResultDTO
    {
        [DataMember()]
        public Int64 DeviceID { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String DName { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        [DataMember()]
        public String DType { get; set; }

        [DataMember()]
        public Double DLat { get; set; }

        [DataMember()]
        public Double DLong { get; set; }

        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String EqpCatgId { get; set; }

        [DataMember()]
        public String EqpCatgName { get; set; }

        [DataMember()]
        public String EqpTypeId { get; set; }

        [DataMember()]
        public String EqpTypeName { get; set; }

        [DataMember()]
        public String EqpId { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String RegionId { get; set; }

        [DataMember()]
        public String RegionName { get; set; }

        [DataMember()]
        public String ZoneId { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String WardId { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String JunctionId { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Long_ { get; set; }

        [DataMember()]
        public String DirectionId { get; set; }

        [DataMember()]
        public String DirectionName { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceiveDateTime { get; set; }

        [DataMember()]
        public String Env_AQI { get; set; }

        public SP_GetEnvironmentTop5Polluted_ResultDTO()
        {
        }

        public SP_GetEnvironmentTop5Polluted_ResultDTO(Int64 deviceID, String externalId, String dName, Nullable<Int32> interfaceId, Nullable<Int32> siteId, String dType, Double dLat, Double dLong, Int32 iD, String eqpCatgId, String eqpCatgName, String eqpTypeId, String eqpTypeName, String eqpId, String status, String regionId, String regionName, String zoneId, String zoneName, String wardId, String wardName, String junctionId, String junctionName, String lat, String long_, String directionId, String directionName, Nullable<DateTime> receiveDateTime, String env_AQI)
        {
            this.DeviceID = deviceID;
            this.ExternalId = externalId;
            this.DName = dName;
            this.InterfaceId = interfaceId;
            this.SiteId = siteId;
            this.DType = dType;
            this.DLat = dLat;
            this.DLong = dLong;
            this.ID = iD;
            this.EqpCatgId = eqpCatgId;
            this.EqpCatgName = eqpCatgName;
            this.EqpTypeId = eqpTypeId;
            this.EqpTypeName = eqpTypeName;
            this.EqpId = eqpId;
            this.Status = status;
            this.RegionId = regionId;
            this.RegionName = regionName;
            this.ZoneId = zoneId;
            this.ZoneName = zoneName;
            this.WardId = wardId;
            this.WardName = wardName;
            this.JunctionId = junctionId;
            this.JunctionName = junctionName;
            this.Lat = lat;
            this.Long_ = long_;
            this.DirectionId = directionId;
            this.DirectionName = directionName;
            this.ReceiveDateTime = receiveDateTime;
            this.Env_AQI = env_AQI;
        }
    }
}
