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
    
    public partial class BBoxPoint
    {
        public int BBoxPointId { get; set; }
        public int SiteId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Alt { get; set; }
        public Nullable<double> PLat { get; set; }
        public Nullable<double> PLong { get; set; }
        public Nullable<double> PAlt { get; set; }
    
        public virtual Site Site { get; set; }
    }
}
