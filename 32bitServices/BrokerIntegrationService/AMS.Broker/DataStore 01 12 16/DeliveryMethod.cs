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
    
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            this.AccountType = new HashSet<AccountType>();
        }
    
        public int DeliveryMethodId { get; set; }
        public string DeliveryMethodName { get; set; }
        public int Frequency { get; set; }
    
        public virtual ICollection<AccountType> AccountType { get; set; }
        public virtual Frequency Frequency1 { get; set; }
    }
}
