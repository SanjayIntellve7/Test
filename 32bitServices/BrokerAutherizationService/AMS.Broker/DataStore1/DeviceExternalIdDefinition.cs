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
    
    public partial class DeviceExternalIdDefinition
    {
        public int EventFieldId { get; set; }
        public int order { get; set; }
        public int InterfaceId { get; set; }
    
        public virtual EventFieldDefinition EventFieldDefinition { get; set; }
        public virtual Interface Interface { get; set; }
    }
}
