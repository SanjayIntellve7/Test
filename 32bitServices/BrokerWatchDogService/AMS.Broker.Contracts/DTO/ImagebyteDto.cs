using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public class ImagebyteDto
    {
        [DataMember()]
        public byte[] ImgbyteArray { get; set; }

        [DataMember()]
        public long DeviceID { get; set; }

        [DataMember()]
        public int PeopleCnt { get; set; }
    }
}
