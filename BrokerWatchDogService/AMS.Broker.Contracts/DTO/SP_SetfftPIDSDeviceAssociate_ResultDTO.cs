using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SetfftPIDSDeviceAssociate_ResultDTO
    {
        [DataMember]
        public string ControllerID { get; set; }
        [DataMember]
        public string ControllerName { get; set; }
        [DataMember]
        public Nullable<int> ZoneID { get; set; }
        [DataMember]
        public string ZoneName { get; set; }
        [DataMember]
        public string DeviceName { get; set; }
        [DataMember]
        public Nullable<int> PresetNo { get; set; }
    }
}
