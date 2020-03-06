using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AccountNvrAlertTypeDto
    {
        [DataMember]
        public int AccountNvrAlertTypeId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int NvrAlertTypeId { get; set; }
    }
}
