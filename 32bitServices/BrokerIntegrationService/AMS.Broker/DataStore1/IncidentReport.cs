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
    
    public partial class IncidentReport
    {
        public IncidentReport()
        {
            this.IncidentReportResource = new HashSet<IncidentReportResource>();
            this.IncidentReportAlert = new HashSet<IncidentReportAlert>();
            this.IncidentReportCamera = new HashSet<IncidentReportCamera>();
            this.IncidentReportStatus = new HashSet<IncidentReportStatus>();
            this.IncidentReportReference = new HashSet<IncidentReportReference>();
            this.IncidentReportReference1 = new HashSet<IncidentReportReference>();
        }
    
        public long IncidentReportId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<IncidentReportResource> IncidentReportResource { get; set; }
        public virtual ICollection<IncidentReportAlert> IncidentReportAlert { get; set; }
        public virtual ICollection<IncidentReportCamera> IncidentReportCamera { get; set; }
        public virtual ICollection<IncidentReportStatus> IncidentReportStatus { get; set; }
        public virtual ICollection<IncidentReportReference> IncidentReportReference { get; set; }
        public virtual ICollection<IncidentReportReference> IncidentReportReference1 { get; set; }
    }
}
