using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract(), Serializable]
    public class tblIDSPanelPartitionStatus
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String PartName { get; set; }

        [DataMember()]
        public String PartStatus { get; set; }

        [DataMember()]
        public List<ZonesInPart> ZonesInPart { get; set; }

    }

    [DataContract()]
    public class ZonesInPart
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String BypassState { get; set; }

        [DataMember()]
        public String FaultState { get; set; }
    }


}
