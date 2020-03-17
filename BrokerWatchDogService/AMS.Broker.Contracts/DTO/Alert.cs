using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(Info)), KnownType(typeof(DeviceDto)), Serializable]
    [DebuggerDisplay("{AlertId}")]
    public class Alert
    {
        public Alert()
        {
            InfoCollection = new List<Info>(16);
        }

        [DataMember]
        public Guid AuthToken { get; set; }

        [DataMember, Required, Key]
        public Int64 AlertId { get; set; }
        [DataMember, Required]
        public String Identifier { get; set; }
        [DataMember, Required]
        public String Sender { get; set; }

        [DataMember, Required]
        public DateTime Sent
        {
            get ;
            set;
           // get { return DateTime.Parse(SentAsString); }
            //set { SentAsString = value.ToString(); }
        }
        [DataMember]
        public string SentAsString { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Time { get; set; }

        [DataMember, Required]
        public Status StatusId { get; set; }
        [DataMember, Required]
        public MessageType MessageTypeId { get; set; }
        [DataMember, Required]
        public Scope ScopeId { get; set; }
        [DataMember]
        public String Source { get; set; }
        [DataMember]
        public String Restriction { get; set; }
        [DataMember]
        public String Addresses { get ; set; }
        [DataMember]
        public String Code { get; set; }
        [DataMember]
        public String Note { get; set; }
        [DataMember]
        public string MemberName { get; set; }
        [DataMember]
        public string MemLocation { get; set; }
        [DataMember]
        public String References { get; set; }
        [DataMember]
        public String Incidents { get; set; }
        [DataMember]
        public List<Info> InfoCollection { get; set; }
        [DataMember]
        public string WorkflowStatus { get; set; }
        [DataMember]
        public bool HasIncidentReport { get; set; }

        [DataMember]
        public bool HasIncidentReportRef { get; set; }

        public bool HasLocation()
        {
            var hasLocation = false;

            foreach (var areasCollection in InfoCollection.Select(x => x.AreasCollection))
            {
                foreach (var area in areasCollection)
                {
                    if (area.Latitude.HasValue && area.Longitude.HasValue)
                    {
                        hasLocation = true;
                        break;
                    }
                }
            }
            return hasLocation;
        }

        [DataMember]
        public DeviceDto DeviceDto { get; set; }

        [DataMember]
        public long DeviceId { get; set; }
        
        public Urgency Urgency { get; set; }

        [DataMember]
        public Certainty Certainty { get; set; }
        
        [DataMember]
        public Severity Severity { get; set; }

        public string MessageTypeString
        {
            get
            {
                switch (MessageTypeId)
                {
                    case MessageType.Ack:
                        return "Acknowledged";
                    case MessageType.Cancel:
                        return "Closed";
                    default:
                        return MessageTypeId.ToString();
                }
            }
            set
            {
                
            }
        }

        [DataMember]
        public IList<VideoAanalyticsEventDTO> VideoAanalyticsEvent { get; set; }
        [DataMember]
        public IList<BioAlertsDTO> BioAlerts { get; set; }
        [DataMember, Required]
        public DateTime ReceivedDateTime { get; set; }

        [DataMember, Required]
        public string AlertAckDateTime { get; set; }

        [DataMember, Required]
        public string AlertCloseDateTime { get; set; }            

        [DataMember]
        public Guid MembershipUserId { get; set; }

        [DataMember]
        public string AlertOwner { get; set; }

        [DataMember]
        public String AlertAttachedDateTime { get; set; }

        [DataMember]
        public string AlertZone { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }

        [DataMember]
        public long EventID { get; set; }

        [DataMember]
        public string AlertContext { get; set; } //for thinclient alert context amit 18012018

        [DataMember]
        public byte[] SnapShotByteArray { get; set; } //for thinclient alert context amit 18012018

        [DataMember()]
        public Int32 CloseReasonID { get; set; }

        [DataMember()]
        public bool IsDevice { get; set; }

        [DataMember()]
        public bool IsAccount { get; set; }

        [DataMember()]
        public string ResourceID { get; set; }
        
    }
}
