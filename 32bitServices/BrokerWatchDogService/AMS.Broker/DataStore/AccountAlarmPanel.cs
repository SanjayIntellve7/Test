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
    
    public partial class AccountAlarmPanel
    {
        public int AccountAlarmPanelId { get; set; }
        public int AccountId { get; set; }
        public int EventGroupId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual EventGroup EventGroup { get; set; }
    }
}
