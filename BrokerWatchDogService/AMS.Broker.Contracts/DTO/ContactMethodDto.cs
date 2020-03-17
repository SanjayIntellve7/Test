using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class ContactMethodDto
    {
        [DataMember]
        public int ContactMethodId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
