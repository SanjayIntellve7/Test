using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class MirasysAlertData
    {
        public string DeviceName { get; set; }
        public string Eventcode { get; set; }
        public string AlertDateTime { get; set; }
        public byte[] Imagedata { get; set; }
    }
}
