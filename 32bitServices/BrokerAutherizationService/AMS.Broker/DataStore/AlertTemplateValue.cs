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
    
    public partial class AlertTemplateValue
    {
        public int AlertTemplateValueId { get; set; }
        public int AlertTemplateId { get; set; }
        public string AlertEntityName { get; set; }
        public string AlertFieldName { get; set; }
        public string ValueFormula { get; set; }
    
        public virtual AlertTemplate AlertTemplate { get; set; }
    }
}
