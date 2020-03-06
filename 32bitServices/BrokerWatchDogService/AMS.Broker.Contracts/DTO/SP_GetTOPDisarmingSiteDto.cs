using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetTOPDisarmingSiteDto
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> EventCount { get; set; }

        [DataMember()]
        public String SiteName { get; set; }

        public SP_GetTOPDisarmingSiteDto()
        {
        }

        public SP_GetTOPDisarmingSiteDto(Int32 iD, Nullable<Int32> eventCount, String siteName)
        {
            this.ID = iD;
            this.EventCount = eventCount;
            this.SiteName = siteName;
        }
    }

}
