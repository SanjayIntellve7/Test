using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetNoEventsReceivedDto
    {
        [DataMember()]
        public Int32 SiteId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        public SP_GetNoEventsReceivedDto()
        {
        }

        public SP_GetNoEventsReceivedDto(Int32 siteId, String name)
        {
            this.SiteId = siteId;
            this.Name = name;
        }
    }

}
