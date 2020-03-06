//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.IntegrationService.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Site
    {
        public Site()
        {
            this.Area = new HashSet<Area>();
            this.BBoxPoint = new HashSet<BBoxPoint>();
            this.Device = new HashSet<Device>();
            this.Site1 = new HashSet<Site>();
            this.Interface = new HashSet<Interface>();
        }
    
        public int SiteId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Alt { get; set; }
        public byte[] Map { get; set; }
        public byte[] Pin { get; set; }
        public string MapUrl { get; set; }
        public string PinUrl { get; set; }
        public Nullable<int> siteTypeId { get; set; }
        public byte[] Icon { get; set; }
        public Nullable<int> AddressId { get; set; }
        public string ExternalIdentifier { get; set; }
        public byte[] BBox { get; set; }
        public Nullable<double> PLat { get; set; }
        public Nullable<double> PLong { get; set; }
        public Nullable<double> PAlt { get; set; }
        public Nullable<double> ZoomLevel { get; set; }
        public Nullable<bool> IsBingMap { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<BBoxPoint> BBoxPoint { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Site> Site1 { get; set; }
        public virtual Site Site2 { get; set; }
        public virtual SiteType SiteType { get; set; }
        public virtual ICollection<Interface> Interface { get; set; }
    }
}
