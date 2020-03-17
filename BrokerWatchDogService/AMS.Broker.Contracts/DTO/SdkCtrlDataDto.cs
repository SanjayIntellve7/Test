using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SdkCtrlDataDto
    {
        public bool Connected { get; set; }
        public string Description { get; set; }
        public string HostName { get; set; }
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public bool Locator { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
    }   
}
