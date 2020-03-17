using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class tblsmarthomeeventcodeDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int C_Eventcode { get; set; }

        [DataMember]
        public string C_Event { get; set; }

    }
}
