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
    
    public partial class AlertHistory
    {
        public long AlertHistoryId { get; set; }
        public long AlertId { get; set; }
        public string UserName { get; set; }
        public string MessageTypeId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Alert Alert { get; set; }
        public virtual MessageType MessageType { get; set; }
    }
}
