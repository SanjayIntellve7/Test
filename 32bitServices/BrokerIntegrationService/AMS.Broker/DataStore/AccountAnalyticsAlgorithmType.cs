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
    
    public partial class AccountAnalyticsAlgorithmType
    {
        public int AccountAnalyticsAlgorithmTypeId { get; set; }
        public int AccountId { get; set; }
        public int AnalyticsAlgorithTypeId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual AnalyticAlgorithmType AnalyticAlgorithmType { get; set; }
    }
}
