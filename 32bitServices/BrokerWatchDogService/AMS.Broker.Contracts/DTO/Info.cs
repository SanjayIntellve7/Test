using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class Info
    {
        public Info()
        { 
            ParametersCollection = new List<Parameter>();
            CategoriesCollection = new List<Category>();
            ResponseTypesCollection = new List<ResponseType>();
            ResourcesCollection = new List<Resource>();
            AreasCollection = new List<Area>();
            Event = String.Empty;
        }

        [DataMember, Required, Key]
        public Int64 InfoId { get; set; }
        [DataMember, Required]
        public Urgency UrgencyId { get; set; }
        [DataMember, Required]
        public Severity SeverityId { get; set; }
        [DataMember, Required]
        public Certainty CertaintyId { get; set; }

        [DataMember]
        public String Language { get; set; }
        [DataMember]
        public String Event { get; set; }
        [DataMember]
        public String Audience { get; set; }
        [DataMember]
        public String Effective { get; set; }
        [DataMember]
        public String OnSet { get; set; }
        [DataMember]
        public String Expires { get; set; }
        [DataMember]
        public String SenderName { get; set; }
        [DataMember]
        public String Headline { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Instruction { get; set; }
        [DataMember]
        public String Web { get; set; }
        [DataMember]
        public String Contact { get; set; }
        [DataMember]
        public String AlertId { get; set; }

        [DataMember]
        public List<Area> AreasCollection { get; set; }
        [DataMember]
        public List<Resource> ResourcesCollection { get; set; }
        [DataMember]
        public List<ResponseType> ResponseTypesCollection { get; set; }
        [DataMember]
        public List<Category> CategoriesCollection { get; set; }
        
        [DataMember]
        public List<Parameter> ParametersCollection { get; set; }

        [DataMember]
        public Int64 EventCode { get; set; }

        [DataMember]
        public String CloseAllContext { get; set; } 
    }
}

