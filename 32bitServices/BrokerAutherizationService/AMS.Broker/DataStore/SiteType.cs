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
    
    public partial class SiteType
    {
        public SiteType()
        {
            this.GeoBox = new HashSet<GeoBox>();
            this.Site = new HashSet<Site>();
        }
    
        public int siteTypeId { get; set; }
        public string siteTypeName { get; set; }
        public string Description { get; set; }
        public byte[] Icon { get; set; }
        public int HierarchyLevel { get; set; }
    
        public virtual ICollection<GeoBox> GeoBox { get; set; }
        public virtual ICollection<Site> Site { get; set; }
    }
}
