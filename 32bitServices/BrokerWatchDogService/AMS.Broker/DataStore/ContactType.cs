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
    
    public partial class ContactType
    {
        public ContactType()
        {
            this.PersonContactType = new HashSet<PersonContactType>();
        }
    
        public int ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }
    
        public virtual ICollection<PersonContactType> PersonContactType { get; set; }
    }
}