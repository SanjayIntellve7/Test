using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract] 
    public class AnalyticAlgorithmTypeDto
    {
        [DataMember]
        public int AnalyticAlgorithmId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
