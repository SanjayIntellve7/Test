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
    
    public partial class IncidentReportAlert
    {
        public long IncidentReportAlertsId { get; set; }
        public long IncidentReportId { get; set; }
        public long AlertId { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string IncidentReportEvidence { get; set; }
        public Nullable<System.DateTime> AttachedDateTime { get; set; }
    
        public virtual Alert Alert { get; set; }
        public virtual IncidentReport IncidentReport { get; set; }
    }
}
