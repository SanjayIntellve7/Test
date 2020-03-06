using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(DeviceDto))]
    public sealed class NVR
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
        public short Port { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public ICollection<DeviceDto> DeviceCollection { get; set; }
    }
}
