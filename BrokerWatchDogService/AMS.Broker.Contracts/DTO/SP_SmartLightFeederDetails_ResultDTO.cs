using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SP_SmartLightFeederDetails_ResultDTO
    {
        [DataMember]
        public string DeviceID { get; set; }

        [DataMember]
        public Nullable<double> Consumption { get; set; }

        [DataMember]
        public string DeviceStatus { get; set; }

        [DataMember]
        public Nullable<int> BurnHour { get; set; }

        [DataMember]
        public int EnergyCost { get; set; }
    }
}
