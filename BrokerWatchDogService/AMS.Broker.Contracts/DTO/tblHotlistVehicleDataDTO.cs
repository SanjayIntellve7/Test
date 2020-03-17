using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblHotlistVehicleDataDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String VehCatId { get; set; }

        [DataMember()]
        public String VehCatName { get; set; }

        [DataMember()]
        public String HotlistCatId { get; set; }

        [DataMember()]
        public String HotlistCatName { get; set; }

        [DataMember()]
        public String VehRestrId { get; set; }

        [DataMember()]
        public String VehNum { get; set; }

        [DataMember()]
        public String EqpId { get; set; }

        [DataMember()]
        public String HotlistFrmDate { get; set; }

        [DataMember()]
        public String HotlistToDate { get; set; }

        [DataMember()]
        public String CapturedDate { get; set; }

        [DataMember()]
        public String EqpCatgId { get; set; }

        [DataMember()]
        public String EqpCatgName { get; set; }

        [DataMember()]
        public String EqpTypeId { get; set; }

        [DataMember()]
        public String EqpTypeName { get; set; }

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
        public String Long { get; set; }

        [DataMember()]
        public String DirectionId { get; set; }

        [DataMember()]
        public String DirectionName { get; set; }

        public tblHotlistVehicleDataDTO()
        {
        }

        public tblHotlistVehicleDataDTO(Int32 iD, String vehCatId, String vehCatName, String hotlistCatId, String hotlistCatName, String vehRestrId, String vehNum, String eqpId, String hotlistFrmDate, String hotlistToDate, String capturedDate, String eqpCatgId, String eqpCatgName, String eqpTypeId, String eqpTypeName, String status, String regionId, String regionName, String zoneId, String zoneName, String wardId, String wardName, String junctionId, String junctionName, String lat, String _long, String directionId, String directionName)
        {
            this.ID = iD;
            this.VehCatId = vehCatId;
            this.VehCatName = vehCatName;
            this.HotlistCatId = hotlistCatId;
            this.HotlistCatName = hotlistCatName;
            this.VehRestrId = vehRestrId;
            this.VehNum = vehNum;
            this.EqpId = eqpId;
            this.HotlistFrmDate = hotlistFrmDate;
            this.HotlistToDate = hotlistToDate;
            this.CapturedDate = capturedDate;
            this.EqpCatgId = eqpCatgId;
            this.EqpCatgName = eqpCatgName;
            this.EqpTypeId = eqpTypeId;
            this.EqpTypeName = eqpTypeName;
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
            this.Long = _long;
            this.DirectionId = directionId;
            this.DirectionName = directionName;
        }
    }
}