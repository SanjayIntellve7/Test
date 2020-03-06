using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class PreferedContatMethodDto
    {
        [DataMember]
        public int PreferedContacMethodtId { get; set; }

        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public int ContactMethodId { get; set; }
    }
}
