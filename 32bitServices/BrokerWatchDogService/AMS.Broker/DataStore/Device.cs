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
    
    public partial class Device
    {
        public Device()
        {
            this.Alert = new HashSet<Alert>();
            this.DevicesInZone = new HashSet<DevicesInZone>();
            this.Event = new HashSet<Event>();
            this.IncidentReportCamera = new HashSet<IncidentReportCamera>();
            this.tbpeoplecounter = new HashSet<tbpeoplecounter>();
            this.tbgeolocation = new HashSet<tbgeolocation>();
            this.SubMember = new HashSet<SubMember>();
        }
    
        public long DeviceId { get; set; }
        public string ExternalId { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
        public string Type { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Altitude { get; set; }
        public string LocationDescription { get; set; }
        public string CameraGuid { get; set; }
        public Nullable<long> NvrId { get; set; }
        public Nullable<int> SiteId { get; set; }
        public bool ActiveAlert { get; set; }
        public Nullable<bool> HasPvAnalytics { get; set; }
        public Nullable<bool> HasSzAnalytics { get; set; }
        public Nullable<bool> HasAbAnalytics { get; set; }
        public Nullable<int> InterfaceId { get; set; }
        public Nullable<bool> IsMovable { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Alert> Alert { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<DevicesInZone> DevicesInZone { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<IncidentReportCamera> IncidentReportCamera { get; set; }
        public virtual Interface Interface { get; set; }
        public virtual ICollection<tbpeoplecounter> tbpeoplecounter { get; set; }
        public virtual ICollection<tbgeolocation> tbgeolocation { get; set; }
        public virtual ICollection<SubMember> SubMember { get; set; }
        public virtual NVR NVR { get; set; }
    }
}