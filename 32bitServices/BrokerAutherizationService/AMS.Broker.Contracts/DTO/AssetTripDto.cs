using AMS.Broker.Contracts.DTO;
using System;
using System.Runtime.Serialization;
[DataContract, KnownType(typeof(Info)), KnownType(typeof(DeviceDto)), Serializable]

    public class AssetTripDto
    {
        [DataMember]
        public string TripName { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public string EndTime { get; set; }
    }
