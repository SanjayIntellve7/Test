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
    
    public partial class Info
    {
        public Info()
        {
            this.Area = new HashSet<Area>();
            this.InfoesCategory = new HashSet<InfoesCategory>();
            this.InfoesResponseType = new HashSet<InfoesResponseType>();
            this.Parameter = new HashSet<Parameter>();
            this.Resource = new HashSet<Resource>();
        }
    
        public long InfoId { get; set; }
        public long AlertId { get; set; }
        public string UrgencyId { get; set; }
        public string Event { get; set; }
        public string SeverityId { get; set; }
        public string CertaintyId { get; set; }
        public string Language { get; set; }
        public Nullable<System.DateTime> OnSet { get; set; }
        public Nullable<System.DateTime> Expires { get; set; }
        public Nullable<System.DateTime> Effective { get; set; }
        public string Audience { get; set; }
        public string SenderName { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public string Web { get; set; }
        public string Contact { get; set; }
    
        public virtual Alert Alert { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual Certainty Certainty { get; set; }
        public virtual Severity Severity { get; set; }
        public virtual Urgency Urgency { get; set; }
        public virtual ICollection<InfoesCategory> InfoesCategory { get; set; }
        public virtual ICollection<InfoesResponseType> InfoesResponseType { get; set; }
        public virtual ICollection<Parameter> Parameter { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
    }
}
