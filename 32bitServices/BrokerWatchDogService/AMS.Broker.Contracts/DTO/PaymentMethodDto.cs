using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class PaymentMethodDto
    {
        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
