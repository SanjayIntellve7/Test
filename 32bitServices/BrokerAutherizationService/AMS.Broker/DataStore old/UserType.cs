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
    
    public partial class UserType
    {
        public UserType()
        {
            this.User1 = new HashSet<User>();
        }
    
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<User> User1 { get; set; }
    }
}
