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
    
    public partial class EventTemplate
    {
        public int EventTemplateId { get; set; }
        public int EventTypeTeplateId { get; set; }
        public int EventCodeId { get; set; }
        public int EventQualifierId { get; set; }
        public string Headline { get; set; }
        public string EventType { get; set; }
        public string MessageType { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Urgency { get; set; }
        public string Severity { get; set; }
        public string Certainty { get; set; }
        public string ResponseType { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public string Scope { get; set; }
    
        public virtual Category Category1 { get; set; }
        public virtual Certainty Certainty1 { get; set; }
        public virtual EventCode EventCode { get; set; }
        public virtual EventQualifier EventQualifier { get; set; }
        public virtual EventTypeTemplate EventTypeTemplate { get; set; }
        public virtual MessageType MessageType1 { get; set; }
        public virtual ResponseType ResponseType1 { get; set; }
        public virtual Severity Severity1 { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual Urgency Urgency1 { get; set; }
        public virtual Scope Scope1 { get; set; }
    }
}