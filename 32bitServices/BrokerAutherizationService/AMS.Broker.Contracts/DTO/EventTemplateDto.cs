using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class EventTemplateDto
    {
        [DataMember()]
        public Int32 EventTemplateId { get; set; }

        [DataMember()]
        public Int32 EventTypeTeplateId { get; set; }

        [DataMember()]
        public Int32 EventCodeId { get; set; }

        [DataMember()]
        public Int32 EventQualifierId { get; set; }

        [DataMember()]
        public String Headline { get; set; }

        [DataMember()]
        public String EventType { get; set; }

        [DataMember()]
        public String MessageType { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String Category { get; set; }

        [DataMember()]
        public String Urgency { get; set; }

        [DataMember()]
        public String Severity { get; set; }

        [DataMember()]
        public String Certainty { get; set; }

        [DataMember()]
        public String ResponseType { get; set; }

        [DataMember()]
        public string Description { get; set; }

        [DataMember()]
        public string Instruction { get; set; }

        [DataMember()]
        public string Scope { get; set; }
    }
}
