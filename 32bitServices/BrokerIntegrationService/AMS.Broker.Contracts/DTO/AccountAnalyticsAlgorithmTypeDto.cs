using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AccountAnalyticsAlgorithmTypeDto
    {
        [DataMember]
        public int AccountAnalyticsAlgorithmTypeId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int AnalyticsAlgorithTypeId { get; set; }
    }
}
