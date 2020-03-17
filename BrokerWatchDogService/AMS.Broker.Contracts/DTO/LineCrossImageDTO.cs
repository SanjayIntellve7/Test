using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class LineCrossImageDTO
    {
        public LineCrossImageDTO() { }

        [DataMember]
        public string DeviceID { get; set; }
        [DataMember]
        public byte[] ImgbyteArray { get; set; }
        [DataMember]
        public int PeopleCnt { get; set; }
        [DataMember]
        public string VAType { get; set; }
    }
}
