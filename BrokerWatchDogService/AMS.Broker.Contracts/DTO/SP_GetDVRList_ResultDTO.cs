using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetDVRList_ResultDTO
    {
        [DataMember()]
        public Int32 SiteId { get; set; }

        [DataMember()]
        public Int32 InterfaceId { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public String Username { get; set; }

        [DataMember()]
        public String Password { get; set; }

        [DataMember()]
        public Int32 Port { get; set; }

        public SP_GetDVRList_ResultDTO()
        {
        }

        public SP_GetDVRList_ResultDTO(Int32 siteId, Int32 interfaceId, String iPAddress, String username, String password, Int32 port)
        {
            this.SiteId = siteId;
            this.InterfaceId = interfaceId;
            this.IPAddress = iPAddress;
            this.Username = username;
            this.Password = password;
            this.Port = port;
        }
    }
}
