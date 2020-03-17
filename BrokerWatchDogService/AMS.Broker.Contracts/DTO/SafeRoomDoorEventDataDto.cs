using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SafeRoomDoorEventDataDto
    {
        public SafeRoomDev Device { get; set; }
    }

    public class SafeRoomEvent
    {      
        public string InputEvent { get; set; }
    
        public string WaitTimeSec { get; set; }
       
        public string ExpectedEvent { get; set; }
    }

    public class SafeRoomDev
    {        
        public Nullable<Int32> AlertDevice { get; set; }       
       
        public string Severity { get; set; }

        public SafeRoomEvent Event { get; set; }
    }
}
