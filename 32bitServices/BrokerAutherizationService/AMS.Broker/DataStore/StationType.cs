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
    
    public partial class StationType
    {
        public StationType()
        {
            this.Station = new HashSet<Station>();
        }
    
        public string StationType1 { get; set; }
    
        public virtual ICollection<Station> Station { get; set; }
    }
}
