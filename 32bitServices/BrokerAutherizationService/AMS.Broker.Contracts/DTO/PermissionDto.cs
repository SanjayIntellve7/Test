using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(OperationDto))]
    public class PermissionDto
    {
        [DataMember]
        public OperationDto Operation { get; set; }

        [DataMember]
        public bool Allow { get; set; }

        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public UsersGroupDto UsersGroup { get; set; }
    }
}
