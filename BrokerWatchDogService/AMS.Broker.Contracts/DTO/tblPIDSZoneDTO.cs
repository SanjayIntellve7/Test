using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPIDSZoneDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> ZoneID { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String ZoneDescription { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsIsolated { get; set; }

        public tblPIDSZoneDTO()
        {
        }

        public tblPIDSZoneDTO(Int32 iD, Nullable<Int32> zoneID, String zoneName, String zoneDescription, Nullable<Boolean> isIsolated)
        {
            this.ID = iD;
            this.ZoneID = zoneID;
            this.ZoneName = zoneName;
            this.ZoneDescription = zoneDescription;
            this.IsIsolated = isIsolated;
        }
    }
}
