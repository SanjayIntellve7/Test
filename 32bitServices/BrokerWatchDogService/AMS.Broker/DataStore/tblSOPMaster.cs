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
    
    public partial class tblSOPMaster
    {
        public tblSOPMaster()
        {
            this.tblSOPAction = new HashSet<tblSOPAction>();
            this.tblSOPTriggerCondition = new HashSet<tblSOPTriggerCondition>();
        }
    
        public int ID { get; set; }
        public string SOPName { get; set; }
        public string Description { get; set; }
        public int SOPTypeID { get; set; }
        public int SOPInputTypeID { get; set; }
    
        public virtual ICollection<tblSOPAction> tblSOPAction { get; set; }
        public virtual tblSOPInputType tblSOPInputType { get; set; }
        public virtual tblSOPType tblSOPType { get; set; }
        public virtual ICollection<tblSOPTriggerCondition> tblSOPTriggerCondition { get; set; }
    }
}
