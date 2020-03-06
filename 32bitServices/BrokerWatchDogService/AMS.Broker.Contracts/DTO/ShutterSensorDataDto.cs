using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{  

    [DataContract()]
    public partial class ShutterSensorDataDto
    {
        [DataMember()]
        public string Severity { get; set; }

        [DataMember()]
        public ShutterSensorOpening Opening { get; set; }
                

        public ShutterSensorDataDto()
        {
        }

        public ShutterSensorDataDto(String severity, ShutterSensorOpening opening)
        {         
            this.Severity = severity;
            this.Opening = opening;            
        }
    }
    public class ShutterSensorOpening
    {     
        public string EventType { get; set; }
    
        public string Zone { get; set; }
       
        public string WaitTime { get; set; }
      
        public string OpeningEventype { get; set; }
      
    }
}
