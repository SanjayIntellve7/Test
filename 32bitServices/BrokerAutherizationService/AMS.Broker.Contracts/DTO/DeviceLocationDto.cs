
#region Assembly AMS.Broker.Contracts.dll, v1.3.0.0
// D:\V1.2.2\Trupti\Broker\AMS.Broker.Contracts\bin\Debug\AMS.Broker.Contracts.dll
#endregion

using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(DeviceDto))]
    [KnownType(typeof(Info))]
    public class DeviceLocationDto
    {   
        [DataMember]
        public string ZoneName { get; set; }
     
        [DataMember]
        public string DeviceName { get; set; }
               
        public DeviceLocationDto()
        {

        }
    }
}

