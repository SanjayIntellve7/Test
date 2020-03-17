using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class UserGroupDetails
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserSid { get; set; }
        [DataMember]
        public Guid? MembershipUserId { get; set; }

        [DataMember]
        public tblDashboardGroupMasterDTO GroupAssociatedWithuser { get; set; }


        public override string ToString()
        {
            return Username;
        }
    }
}
