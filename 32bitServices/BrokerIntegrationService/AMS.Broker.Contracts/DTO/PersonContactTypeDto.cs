using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class PersonContactTypeDto
    {
        [DataMember]
        public int PersonContactTypeId { get; set; }

        [DataMember]
        public int PersonId { get; set; }

        [DataMember]
        public int ContactTypeId { get; set; }
    }
}
