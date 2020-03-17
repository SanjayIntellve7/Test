using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts
{
    class AlertInfo
    {
        public Alert1 Alert1 { get; set; }
    }
    public class Alert1
    {
        public string DeviceName { get; set; }
        public int DeviceID { get; set; }
        public int Eventcode { get; set; }
        public string AlertDateTime { get; set; }
    }  

}
