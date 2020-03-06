using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(PersonDto)), Serializable]
    public class AccountLightDto
    {
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? PrimaryContactId { get; set; }
        [DataMember]
        public PersonDto PrimaryAccountAdministrator { get; set; }
    }
}
