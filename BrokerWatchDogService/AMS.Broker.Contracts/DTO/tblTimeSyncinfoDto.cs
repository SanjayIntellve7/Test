using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class tblTimeSyncinfoDto
    {
        [DataMember]
        public Int32 ID { get; set; }

        [DataMember]
        public Int32 DeviceID { get; set; }

        [DataMember]
        public Int32 DVRNVRTypeID { get; set; }

        [DataMember]
        public Int32 DateTimeSyncStatus { get; set; }

        [DataMember()]
        public String Remarks { get; set; }

    }
}
