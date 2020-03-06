using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    public class DeviceData
    {
        public int flag { get; set; }
        public List<Zone1> zone1 { get; set; }       
    }

    public class Zone1
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public List<Device> Device { get; set; }
    }

    public class Device
    {
        public string DeviceName { get; set; }
        public int DeviceID { get; set; }
        public string DeviceType { get; set; }
    }

    

}
