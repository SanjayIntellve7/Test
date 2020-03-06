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
    
    public partial class AnalyticAlgorithmType
    {
        public AnalyticAlgorithmType()
        {
            this.NvrCamera = new HashSet<NvrCamera>();
            this.AccountAnalyticsAlgorithmType = new HashSet<AccountAnalyticsAlgorithmType>();
            this.AnalyticsEventTemplate = new HashSet<AnalyticsEventTemplate>();
        }
    
        public int AnalyticAlgorithmId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<NvrCamera> NvrCamera { get; set; }
        public virtual ICollection<AccountAnalyticsAlgorithmType> AccountAnalyticsAlgorithmType { get; set; }
        public virtual ICollection<AnalyticsEventTemplate> AnalyticsEventTemplate { get; set; }
    }
}
