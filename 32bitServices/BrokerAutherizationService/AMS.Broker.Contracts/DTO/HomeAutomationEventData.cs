using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class HomeAutomationEventData
    {
        public string sid { get; set; }
        public string contype { get; set; }
        public string msgtype { get; set; }
        public string service { get; set; }
        public HInfo info { get; set; }
        public HLocation location { get; set; }
    }
    public class HInfo
    {
        public string @event { get; set; }
        public string urgency { get; set; }
        public string severity { get; set; }
        public string certainity { get; set; }
        public string status { get; set; }
        public string dateAndTime { get; set; }
    }
    public class HLocation
    {
        public string project { get; set; }
        public string block { get; set; }
        public string tower { get; set; }
        public string property { get; set; }
        public string owner { get; set; }
        public string Zone { get; set; }
        public string contact { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
