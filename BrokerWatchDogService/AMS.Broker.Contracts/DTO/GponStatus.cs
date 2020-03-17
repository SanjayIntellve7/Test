using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class GponOntOltStatus
    {
       public List<OltDevice> OltDevice { get; set; }       
    }

    public class OltDevice
    {
        public string OltName { get; set; }
        public string OltStatus { get; set; }
        public List<OntDevice> OntDeviceList { get; set; }
    }

    public class OntDevice
    {
        public string OntName { get; set; }

        public string OntStatus { get; set; }

        public List<OntDevicePort> OntDevicePortList { get; set; }
    }    

    public class OntDevicePort
    {
        public string OltPortName { get; set; }

        public string OltPortStatus { get; set; }
    }

}
