using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SP_WardEnergyConsumption_ResultDTO
    {
        [DataMember]
        public Nullable<double> Watt { get; set; }

        [DataMember]
        public string Wardno { get; set; }

        [DataMember]
        public string WardName { get; set; }
    }
}
