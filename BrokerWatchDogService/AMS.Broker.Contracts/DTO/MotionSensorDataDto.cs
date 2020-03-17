using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{  

    [DataContract()]
    public partial class MotionSensorDataDto
    {
        [DataMember()]
        public string Severity { get; set; }

        [DataMember()]
        public MotionSensorOpening Opening { get; set; }
                

        public MotionSensorDataDto()
        {
        }

        public MotionSensorDataDto(String severity, MotionSensorOpening opening)
        {         
            this.Severity = severity;
            this.Opening = opening;            
        }
    }
    public class MotionSensorOpening
    {     
        public string EventType { get; set; }
    
        public string Zone { get; set; }
       
        public string WaitTime { get; set; }
      
        public string OpeningEventype { get; set; }

        public string OpeningZone { get; set; }
    }
}
