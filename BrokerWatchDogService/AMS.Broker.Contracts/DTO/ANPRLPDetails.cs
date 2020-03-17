using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public class ANPRLPDetails
    {
        [DataMember()]
        public string LP_UId { get; set; }

        [DataMember()]
        public string LP_IPAddress { get; set; }

        [DataMember()]
        public string LP_Name { get; set; }

        [DataMember()]
        public string LP_Status { get; set; }
    }
}
