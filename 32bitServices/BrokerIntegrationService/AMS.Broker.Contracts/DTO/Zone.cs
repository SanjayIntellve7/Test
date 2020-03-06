using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(DeviceDto)), KnownType(typeof(ZoneLocations)), Serializable]

    public sealed class Zone
    {
        public Zone()
        {
            DeviceCollection = new List<DeviceDto>(16);
            ZoneLocationCollection = new List<ZoneLocations>(16);
        }
        [DataMember]
        public Guid AuthToken { get; set; }
        [DataMember, Required, Key]
        public Int64 ZoneId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public List<DeviceDto> DeviceCollection { get; set; }
        [DataMember]
        public List<ZoneLocations> ZoneLocationCollection { get; set; }

        [DataMember]
        public string Metadata { get; set; }
    }

}
