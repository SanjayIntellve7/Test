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
    
    public partial class EventQualifier
    {
        public EventQualifier()
        {
            this.EventTemplates = new HashSet<EventTemplate>();
        }
    
        public int EventQualifierId { get; set; }
        public string EventQualifierDescription { get; set; }
    
        public virtual ICollection<EventTemplate> EventTemplates { get; set; }
    }
}
