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
    
    public partial class PersonContactType
    {
        public int PersonContactTypeId { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
    
        public virtual ContactType ContactType { get; set; }
        public virtual Person Person { get; set; }
    }
}
