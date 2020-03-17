using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_CitizenCompalintTrend_ResultDTO
    {
        [DataMember()]
        public String WeekName { get; set; }

        [DataMember()]
        public Nullable<DateTime> SentDate { get; set; }

        [DataMember()]
        public String FullName { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public String Location { get; set; }

        [DataMember()]
        public Nullable<DateTime> RegisteredDateTime { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public Nullable<DateTime> Sent { get; set; }

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

        public SP_CitizenCompalintTrend_ResultDTO()
        {
        }

        public SP_CitizenCompalintTrend_ResultDTO(String weekName, Nullable<DateTime> sentDate, String fullName, String latitude, String longitude, String location, Nullable<DateTime> registeredDateTime, String status, String wardName, String wardNo, Nullable<DateTime> sent, String statusId, String messageTypeId, String addresses, String code, Nullable<Int32> closeReasonID, String alertContext, Nullable<DateTime> alertAckDateTime, Nullable<DateTime> alertCloseDateTime)
        {
            this.WeekName = weekName;
            this.SentDate = sentDate;
            this.FullName = fullName;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Location = location;
            this.RegisteredDateTime = registeredDateTime;
            this.Status = status;
            this.WardName = wardName;
            this.WardNo = wardNo;
            this.Sent = sent;
            this.StatusId = statusId;
            this.MessageTypeId = messageTypeId;
            this.Addresses = addresses;
            this.Code = code;
            this.CloseReasonID = closeReasonID;
            this.AlertContext = alertContext;
            this.AlertAckDateTime = alertAckDateTime;
            this.AlertCloseDateTime = alertCloseDateTime;
        }
    }
}
