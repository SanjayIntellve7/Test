using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{    
    public class Attribute
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class AlgovisionAnprDto
    {
        public string AlarmDescription { get; set; }
        public string AlarmName { get; set; }
        public string AlarmTime { get; set; }
        public List<Attribute> Attributes { get; set; }
        public string CameraName { get; set; }
        public string EventPublisher { get; set; }
        public string EventType { get; set; }
        public string RegionName { get; set; }
        public string SourceLocation { get; set; }
    }
}
