using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelZoneTypeMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Type { get; set; }

        public tblIDSPanelZoneTypeMasterDTO()
        {
        }

        public tblIDSPanelZoneTypeMasterDTO(Int32 iD, String type)
        {
            this.ID = iD;
            this.Type = type;
        }
    }
}
