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
    
    public partial class ContactMethod
    {
        public ContactMethod()
        {
            this.PreferedContatMethod = new HashSet<PreferedContatMethod>();
        }
    
        public int ContactMethodId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<PreferedContatMethod> PreferedContatMethod { get; set; }
    }
}
