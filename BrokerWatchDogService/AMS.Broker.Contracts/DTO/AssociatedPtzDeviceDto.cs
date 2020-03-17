using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class AssociatedPtzDeviceDto
    {
        [DataMember()]
        public Nullable<Int32> DevId { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public int Port { get; set; }

        [DataMember()]
        public String Username { get; set; }

        [DataMember()]
        public String Password { get; set; }

        [DataMember()]
        public Guid DevGUID { get; set; }

        [DataMember()]
        public int PresetNumber { get; set; }

        [DataMember]
        public int? PTZCamId { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }      
            
            
            
            
    }
}
