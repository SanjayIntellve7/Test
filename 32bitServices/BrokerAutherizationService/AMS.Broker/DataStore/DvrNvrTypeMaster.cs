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
    
    public partial class DvrNvrTypeMaster
    {
        public DvrNvrTypeMaster()
        {
            this.NVR = new HashSet<NVR>();
        }
    
        public int DvrNvrTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<NVR> NVR { get; set; }
    }
}
