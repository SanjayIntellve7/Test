using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ReturnUserObjectNonAssociationList_ResultDTO
    {
        [DataMember()]
        public Int32 ParentObjectID { get; set; }

        [DataMember()]
        public Int32 AssociateDeviceID { get; set; }

        [DataMember()]
        public Int32 SiteId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        public SP_ReturnUserObjectNonAssociationList_ResultDTO()
        {
        }

        public SP_ReturnUserObjectNonAssociationList_ResultDTO(Int32 parentObjectID, Int32 associateDeviceID, Int32 siteId, String name)
        {
            this.ParentObjectID = parentObjectID;
            this.AssociateDeviceID = associateDeviceID;
            this.SiteId = siteId;
            this.Name = name;
        }
    }
}
