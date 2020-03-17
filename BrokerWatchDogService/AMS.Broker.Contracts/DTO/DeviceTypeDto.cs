using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class DeviceTypeDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Int32 DeviceTypeID { get; set; }
    }
}
