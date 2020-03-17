using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class UserGroupData
    {
        [DataMember]
        public List<UserGroupDetails> UsergroupDetailList { get; set; }

        [DataMember]
        public List<tblDashboardGroupMasterDTO> GroupMasterList { get; set; }
    }
}
