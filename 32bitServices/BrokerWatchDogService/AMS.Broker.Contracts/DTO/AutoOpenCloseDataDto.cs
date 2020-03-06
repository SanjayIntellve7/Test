using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{   
    [DataContract()]
    public partial class AutoOpenCloseDataDto
    {
        [DataMember()]
        public string Severity { get; set; }

        [DataMember()]
        public List<AutoOpenCloseDevice> Device  { get; set; }

        public AutoOpenCloseDataDto()
        {
        }

        public AutoOpenCloseDataDto(String severity, List<AutoOpenCloseDevice> device)
        {
            this.Severity = severity;
            this.Device = device;
        }
    }
    public class AutoOpenCloseDevice
    {

        public AutoOpen AutoOpen { get; set; }

        public AutoClose AutoClose { get; set; }

        public string ID { get; set; }
    }

    public class AutoOpen
    {     
        public string EventType { get; set; }
      
        public List<string> EventTime { get; set; }
    }

    
    public class AutoClose
    {        
        public string EventType { get; set; }
        
        public List<string> EventTime { get; set; }
    }
}
