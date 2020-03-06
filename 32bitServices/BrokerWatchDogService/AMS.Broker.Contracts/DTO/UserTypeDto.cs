using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class UserTypeDto
    {
        [DataMember]
        public virtual int UserTypeId { get; set; }

        [DataMember]
        public virtual string UserTypeName { get; set; }
    }
}
