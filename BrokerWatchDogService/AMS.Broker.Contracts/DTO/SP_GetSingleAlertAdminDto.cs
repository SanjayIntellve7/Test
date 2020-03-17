using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(ContactDto)), KnownType(typeof(SiteDto)), Serializable]
    public class SP_GetSingleAlertAdminDto
    {
        [DataMember]
        public long AAlertID { get; set; }

        [DataMember]
        public int MessageTypeId { get; set; }

        [DataMember]
        public Guid MembershipUserId { get; set; }

        [DataMember]
        public string AlertOwner { get; set; }
    }
}
