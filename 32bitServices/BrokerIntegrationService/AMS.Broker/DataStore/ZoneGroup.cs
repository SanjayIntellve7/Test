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
    
    public partial class ZoneGroup
    {
        public long ZoneGroupId { get; set; }
        public long ParenZoneId { get; set; }
        public long ZoneId { get; set; }
    
        public virtual Zone Zone { get; set; }
        public virtual Zone Zone1 { get; set; }
    }
}
