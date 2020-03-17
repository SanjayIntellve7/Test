using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SurveillanceDashboard_ResultDTO
    {
        [DataMember()]
        public Int64 AlertId { get; set; }

        [DataMember()]
        public String Identifier { get; set; }

        [DataMember()]
        public String Sender { get; set; }

        [DataMember()]
        public DateTime Sent { get; set; }

        [DataMember()]
        public String StatusId { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        [DataMember()]
        public String ScopeId { get; set; }

        [DataMember()]
        public String Source { get; set; }

        [DataMember()]
        public String Restriction { get; set; }

        [DataMember()]
        public String Addresses { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public String Note { get; set; }

        [DataMember()]
        public String References { get; set; }

        [DataMember()]
        public String Incidents { get; set; }

        [DataMember()]
        public Nullable<Int64> DeviceId { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDateTime { get; set; }

        [DataMember()]
        public Nullable<Guid> MembershipUserId { get; set; }

        [DataMember()]
        public String AlertOwner { get; set; }

        [DataMember()]
        public String Alertzone { get; set; }

        [DataMember()]
        public Nullable<Int64> EventID { get; set; }

        [DataMember()]
        public String AlertContext { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertAckDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertCloseDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> CloseReasonID { get; set; }

        [DataMember()]
        public String Comments { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public Nullable<Boolean> Status { get; set; }

        public SP_SurveillanceDashboard_ResultDTO()
        {
        }

        public SP_SurveillanceDashboard_ResultDTO(Int64 alertId, String identifier, String sender, DateTime sent, String statusId, String messageTypeId, String scopeId, String source, String restriction, String addresses, String code, String note, String references, String incidents, Nullable<Int64> deviceId, Nullable<DateTime> receivedDateTime, Nullable<Guid> membershipUserId, String alertOwner, String alertzone, Nullable<Int64> eventID, String alertContext, Nullable<DateTime> alertAckDateTime, Nullable<DateTime> alertCloseDateTime, Nullable<Int32> closeReasonID, String comments, Double lat, Double long_, Nullable<Boolean> status)
        {
            this.AlertId = alertId;
            this.Identifier = identifier;
            this.Sender = sender;
            this.Sent = sent;
            this.StatusId = statusId;
            this.MessageTypeId = messageTypeId;
            this.ScopeId = scopeId;
            this.Source = source;
            this.Restriction = restriction;
            this.Addresses = addresses;
            this.Code = code;
            this.Note = note;
            this.References = references;
            this.Incidents = incidents;
            this.DeviceId = deviceId;
            this.ReceivedDateTime = receivedDateTime;
            this.MembershipUserId = membershipUserId;
            this.AlertOwner = alertOwner;
            this.Alertzone = alertzone;
            this.EventID = eventID;
            this.AlertContext = alertContext;
            this.AlertAckDateTime = alertAckDateTime;
            this.AlertCloseDateTime = alertCloseDateTime;
            this.CloseReasonID = closeReasonID;
            this.Comments = comments;
            this.Lat = lat;
            this.Long_ = long_;
            this.Status = status;
        }
    }
}
