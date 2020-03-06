using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblDvrChanelMasterDto
    {
        [DataMember]
        public Int64 ID { get; set; }

        [DataMember]
        public int? InterfaceId { get; set; }


        [DataMember]
        public int? Chanel { get; set; }
    }
}
