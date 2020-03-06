//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.AutherizationService.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int EventId { get; set; }
        public long DeviceId { get; set; }
        public Nullable<long> PanelAccountId { get; set; }
        public string EventCode { get; set; }
        public System.DateTime TimeSent { get; set; }
        public string ExternalMessage { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<long> AlertId { get; set; }
        public Nullable<int> FrameTypeCode { get; set; }
        public Nullable<int> FrameId { get; set; }
        public string Qualifier { get; set; }
        public string ZoneCode { get; set; }
        public string LineCode { get; set; }
        public string DriverName { get; set; }
        public string DriverPortNumber { get; set; }
        public string EventDevID { get; set; }
        public string ZoneSubsystem { get; set; }
    
        public virtual Alert Alert { get; set; }
        public virtual Area Area { get; set; }
        public virtual Device Device { get; set; }
    }
}
