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
    
    public partial class InfoesResponseType
    {
        public long InfoId { get; set; }
        public string ResponseType { get; set; }
        public long Id { get; set; }
    
        public virtual Info Info { get; set; }
        public virtual ResponseType ResponseType1 { get; set; }
    }
}
