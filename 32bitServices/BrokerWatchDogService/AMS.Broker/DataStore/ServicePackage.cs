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
    
    public partial class ServicePackage
    {
        public ServicePackage()
        {
            this.Account = new HashSet<Account>();
        }
    
        public int ServicePackageId { get; set; }
        public string Name { get; set; }
        public decimal PackagePrice { get; set; }
    
        public virtual ICollection<Account> Account { get; set; }
    }
}
