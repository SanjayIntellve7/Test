//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alert
    {
        public Alert()
        {
            this.AlertHistory = new HashSet<AlertHistory>();
            this.Event = new HashSet<Event>();
            this.IncidentReportAlert = new HashSet<IncidentReportAlert>();
            this.Info = new HashSet<Info>();
            this.VideoAanalyticsEvent = new HashSet<VideoAanalyticsEvent>();
            this.BioAlerts = new HashSet<BioAlerts>();
        }
    
        public long AlertId { get; set; }
        public string Identifier { get; set; }
        public string Sender { get; set; }
        public System.DateTime Sent { get; set; }
        public string StatusId { get; set; }
        public string MessageTypeId { get; set; }
        public string ScopeId { get; set; }
        public string Source { get; set; }
        public string Restriction { get; set; }
        public string Addresses { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string References { get; set; }
        public string Incidents { get; set; }
        public Nullable<long> DeviceId { get; set; }
        public Nullable<System.DateTime> ReceivedDateTime { get; set; }
        public Nullable<System.Guid> MembershipUserId { get; set; }
        public string AlertOwner { get; set; }
        public string Alertzone { get; set; }
        public Nullable<long> EventID { get; set; }
        public string AlertContext { get; set; }
        public Nullable<System.DateTime> AlertAckDateTime { get; set; }
        public Nullable<System.DateTime> AlertCloseDateTime { get; set; }
        public Nullable<int> CloseReasonID { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<AlertHistory> AlertHistory { get; set; }
        public virtual Device Device { get; set; }
        public virtual MessageType MessageType { get; set; }
        public virtual Scope Scope { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<IncidentReportAlert> IncidentReportAlert { get; set; }
        public virtual ICollection<Info> Info { get; set; }
        public virtual ICollection<VideoAanalyticsEvent> VideoAanalyticsEvent { get; set; }
        public virtual ICollection<BioAlerts> BioAlerts { get; set; }
    }
}