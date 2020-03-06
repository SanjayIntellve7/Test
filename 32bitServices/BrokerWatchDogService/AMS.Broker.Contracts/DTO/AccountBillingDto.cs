using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(PaymentMethodDto)), KnownType(typeof(AddressDto))]
    public class AccountBillingDto
    {
        [DataMember]
        public int AccountBillingId { get; set; }

        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public int AddressId { get; set; }

        [DataMember]
        public PaymentMethodDto PaymentMethod { get; set; }

        [DataMember]
        public AddressDto Address { get; set; }
    }
}
