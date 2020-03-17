using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public class ANPRCameraDetails
    {
        [DataMember()]
        public string ANPR_LP_UId { get; set; }

        [DataMember()]
        public string Camera_IPAddress { get; set; }

        [DataMember()]
        public string Camera_Name { get; set; }

        [DataMember()]
        public string Camera_Status { get; set; }
    }
}
