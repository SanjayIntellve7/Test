using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class GponRootObject
    {
        public string crossConnectVlanRanges { get; set; }
        public string productAndRelease { get; set; }
        public string role { get; set; }
        public Links _links { get; set; }
        public string supervision { get; set; }
        public string name { get; set; }
        public string ipAddress { get; set; }
        public string activeSoftwareVersion { get; set; }
        public string protectionOlt { get; set; }
    }
    public class Links
    {
        public string slots { get; set; }
        public string lags { get; set; }
        public string uplinks { get; set; }
        public string channelpairs { get; set; }
        public string ponports { get; set; }
        public string onts { get; set; }
        public string ontports { get; set; }
    }
}
