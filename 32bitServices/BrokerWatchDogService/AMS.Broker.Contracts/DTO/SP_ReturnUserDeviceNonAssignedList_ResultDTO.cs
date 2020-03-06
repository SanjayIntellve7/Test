using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ReturnUserDeviceNonAssignedList_ResultDTO
    {
        [DataMember()]
        public Nullable<Guid> UserID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String UserName { get; set; }

        [DataMember()]
        public String FullName { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        public SP_ReturnUserDeviceNonAssignedList_ResultDTO()
        {
        }

        public SP_ReturnUserDeviceNonAssignedList_ResultDTO(Nullable<Guid> userID, Nullable<Int32> deviceID, String name, String userName, String fullName, Nullable<Int32> siteId)
        {
            this.UserID = userID;
            this.DeviceID = deviceID;
            this.Name = name;
            this.UserName = userName;
            this.FullName = fullName;
            this.SiteId = siteId;
        }
    }
}
