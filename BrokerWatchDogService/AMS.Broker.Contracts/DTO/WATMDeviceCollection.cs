using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class WATMDeviceCollection
    {

        [DataMember]
        public List<tblWATMCollectionDTO> WATMTxnCollection { get; set; }

        [DataMember]
        public List<tblWATMDispenserStatusDTO> WATMDispenserStatusCol { get; set; }

        [DataMember()]
        public String WATMDeviceId { get; set; }

        [DataMember()]
        public String WATMStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> WATMUpdatedTime { get; set; }

    }
}
