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
    
    public partial class IncidentReportCamera
    {
        public long IncidentReportCamerasId { get; set; }
        public long IncidentReportId { get; set; }
        public long CameraId { get; set; }
        public Nullable<int> Sequence { get; set; }
        public System.DateTime PlyDateTime { get; set; }
        public Nullable<System.DateTime> AttachedDatime { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual IncidentReport IncidentReport { get; set; }
    }
}
