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
    
    public partial class ResponseType
    {
        public ResponseType()
        {
            this.InfoesResponseType = new HashSet<InfoesResponseType>();
            this.EventTemplates = new HashSet<EventTemplate>();
            this.AnalyticsEventTemplate = new HashSet<AnalyticsEventTemplate>();
        }
    
        public string Name { get; set; }
    
        public virtual ICollection<InfoesResponseType> InfoesResponseType { get; set; }
        public virtual ICollection<EventTemplate> EventTemplates { get; set; }
        public virtual ICollection<AnalyticsEventTemplate> AnalyticsEventTemplate { get; set; }
    }
}
