using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetTop10AlertGenerateSiteDto
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> AlertCount { get; set; }

        [DataMember()]
        public String SiteName { get; set; }

        public SP_GetTop10AlertGenerateSiteDto()
        {
        }

        public SP_GetTop10AlertGenerateSiteDto(Int32 iD, Nullable<Int32> alertCount, String siteName)
        {
            this.ID = iD;
            this.AlertCount = alertCount;
            this.SiteName = siteName;
        }
    }

}
