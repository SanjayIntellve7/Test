using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class Mask
    {
        [DataMember]
        public int RowsCount { get; set; }
        [DataMember]
        public int ColsCount { get; set; }
        [DataMember]
        public byte[] Blob { get; set; }
    }
}
