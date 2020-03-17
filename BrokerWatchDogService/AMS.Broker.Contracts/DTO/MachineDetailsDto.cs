using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class MachineDetailsDto
    {
        [DataMember]
        public List<string> selectedClient { get; set; }

        [DataMember]
        public string machineName { get; set; }

        [DataMember]
        public string macAddress { get; set; }

        [DataMember]
        public string machineIP { get; set; }

    }
}
