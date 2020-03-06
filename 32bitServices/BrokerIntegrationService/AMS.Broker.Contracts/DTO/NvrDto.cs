using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract,KnownType(typeof(DeviceDto))]
    public sealed class NvrDto
    {
        [DataMember]
        public Int64 NvrId { get; set; }

        [DataMember]
        public string NvrUrl { get; set; }

        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Port { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int InterfaceId { get; set; }

        [DataMember]
        public int DvrNvrTypeId { get; set; }

        [DataMember]
        public IEnumerable<DeviceDto> Cameras { get; set; }
        [DataMember]
        public int Lane1 { get; set; }
        [DataMember]
        public int Lane2 { get; set; }
        [DataMember]
        public int Lane3 { get; set; }
    }
}
