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
    
    public partial class EventGroup
    {
        public EventGroup()
        {
            this.EventCodes = new HashSet<EventCode>();
            this.AccountAlarmPanel = new HashSet<AccountAlarmPanel>();
        }
    
        public int EventGroupId { get; set; }
        public int EventCodeMin { get; set; }
        public int EventCodeMax { get; set; }
        public string EventCodeGroupDescription { get; set; }
    
        public virtual ICollection<EventCode> EventCodes { get; set; }
        public virtual ICollection<AccountAlarmPanel> AccountAlarmPanel { get; set; }
    }
}