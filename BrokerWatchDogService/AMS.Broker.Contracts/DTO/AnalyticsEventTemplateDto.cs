using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AnalyticsEventTemplateDto
    {
        [DataMember]
        public int AnalyticsEventTemplateId { get; set; }

        [DataMember]
        public int EventTypeTeplateId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Headline { get; set; }

        [DataMember]
        public string EventType { get; set; }

        [DataMember]
        public string MessageType { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Urgency { get; set; }

        [DataMember]
        public string Severity { get; set; }

        [DataMember]
        public string Certainty { get; set; }

        [DataMember]
        public string ResponseType { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Instruction { get; set; }

        [DataMember]
        public string Scope { get; set; }

        [DataMember]
        public int AnalyticAlgorithmTypeId { get; set; }
    }
}
