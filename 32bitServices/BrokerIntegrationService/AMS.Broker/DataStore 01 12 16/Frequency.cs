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
    
    public partial class Frequency
    {
        public Frequency()
        {
            this.DeliveryMethod = new HashSet<DeliveryMethod>();
        }
    
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public Nullable<System.TimeSpan> Hour { get; set; }
        public Nullable<int> DayOfWeek { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> DayOfMonth { get; set; }
    
        public virtual ICollection<DeliveryMethod> DeliveryMethod { get; set; }
    }
}
