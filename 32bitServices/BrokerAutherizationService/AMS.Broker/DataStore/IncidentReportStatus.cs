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
    
    public partial class IncidentReportStatus
    {
        public long IncidentReportStatusId { get; set; }
        public long IncidentReportId { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.Guid> AuthToken { get; set; }
    
        public virtual IncidentReport IncidentReport { get; set; }
    }
}
