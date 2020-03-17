using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetPanelStatusDto
    {
        //komal14012020
        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public String IDSStatusDescription { get; set; }

        [DataMember()]
        public Nullable<Int32> IDSStatusID { get; set; }

        public SP_GetPanelStatusDto()
        {
        }

        public SP_GetPanelStatusDto(String name, String externalId, String iPAddress, String iDSStatusDescription, Nullable<Int32> iDSStatusID)
        {
            this.Name = name;
            this.ExternalId = externalId;
            this.IPAddress = iPAddress;
            this.IDSStatusDescription = iDSStatusDescription;
            this.IDSStatusID = iDSStatusID;
        }
    }
}
