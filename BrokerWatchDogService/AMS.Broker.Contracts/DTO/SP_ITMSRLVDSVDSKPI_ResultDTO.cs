using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ITMSRLVDSVDSKPI_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String ViolationName { get; set; }

        [DataMember()]
        public String ViolationCatgId { get; set; }

        [DataMember()]
        public String ViolationCatgName { get; set; }

        [DataMember()]
        public String ViolationId { get; set; }

        [DataMember()]
        public String EqpId { get; set; }

        [DataMember()]
        public String EqpId2 { get; set; }

        [DataMember()]
        public String ImgPath { get; set; }

        [DataMember()]
        public String ImageFileName { get; set; }

        [DataMember()]
        public String VidPath { get; set; }

        [DataMember()]
        public String NpColor { get; set; }

        [DataMember()]
        public String NpText { get; set; }

        [DataMember()]
        public String ViolationTime { get; set; }

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
        public String Long_ { get; set; }

        [DataMember()]
        public String DirectionId { get; set; }

        [DataMember()]
        public String DirectionName { get; set; }

        [DataMember()]
        public Nullable<Int64> AlertId { get; set; }

        [DataMember()]
        public String imageFileName1 { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public DateTime Sent { get; set; }

        [DataMember()]
        public String StatusId { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        [DataMember()]
        public String Addresses { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public Nullable<Int32> CloseReasonID { get; set; }

        [DataMember()]
        public String AlertContext { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertAckDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertCloseDateTime { get; set; }

        [DataMember()]
        public String Status1 { get; set; }

        public SP_ITMSRLVDSVDSKPI_ResultDTO()
        {
        }

        public SP_ITMSRLVDSVDSKPI_ResultDTO(Int32 iD, String violationName, String violationCatgId, String violationCatgName, String violationId, String eqpId, String eqpId2, String imgPath, String imageFileName, String vidPath, String npColor, String npText, String violationTime, String eqpCatgId, String eqpCatgName, String eqpTypeId, String eqpTypeName, String status, String regionId, String regionName, String zoneId, String zoneName, String wardId, String wardName, String junctionId, String junctionName, String lat, String long_, String directionId, String directionName, Nullable<Int64> alertId, String imageFileName1, String name, DateTime sent, String statusId, String messageTypeId, String addresses, String code, Nullable<Int32> closeReasonID, String alertContext, Nullable<DateTime> alertAckDateTime, Nullable<DateTime> alertCloseDateTime, String status1)
        {
            this.ID = iD;
            this.ViolationName = violationName;
            this.ViolationCatgId = violationCatgId;
            this.ViolationCatgName = violationCatgName;
            this.ViolationId = violationId;
            this.EqpId = eqpId;
            this.EqpId2 = eqpId2;
            this.ImgPath = imgPath;
            this.ImageFileName = imageFileName;
            this.VidPath = vidPath;
            this.NpColor = npColor;
            this.NpText = npText;
            this.ViolationTime = violationTime;
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
            this.Long_ = long_;
            this.DirectionId = directionId;
            this.DirectionName = directionName;
            this.AlertId = alertId;
            this.imageFileName1 = imageFileName1;
            this.Name = name;
            this.Sent = sent;
            this.StatusId = statusId;
            this.MessageTypeId = messageTypeId;
            this.Addresses = addresses;
            this.Code = code;
            this.CloseReasonID = closeReasonID;
            this.AlertContext = alertContext;
            this.AlertAckDateTime = alertAckDateTime;
            this.AlertCloseDateTime = alertCloseDateTime;
            this.Status1 = status1;
        }
    }
}
