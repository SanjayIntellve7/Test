using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetRLVDZoneIncidentCountDto
    {
        [DataMember()]
        public Nullable<Int32> IncidentCount { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        public SP_GetRLVDZoneIncidentCountDto()
        {
        }

        public SP_GetRLVDZoneIncidentCountDto(Nullable<Int32> incidentCount, String zoneName)
        {
            this.IncidentCount = incidentCount;
            this.ZoneName = zoneName;
        }
    }
}
