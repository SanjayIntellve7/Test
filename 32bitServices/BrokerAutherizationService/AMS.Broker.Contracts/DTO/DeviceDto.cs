using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [XmlInclude(typeof(NvrCameraDto))]
    [DataContract, KnownType(typeof(NvrCameraDto)), KnownType(typeof(DeviceVAnalyticsScheduleDTO))]
    /*[XmlInclude(typeof(SubMemberDTO))]*/
    [XmlInclude(typeof(DeviceVAnalyticsScheduleDTO))]
   
    public class DeviceDto
    {
        [DataMember]
        public Int64 DeviceId { get; set; }
        [DataMember]
        public String ExternalId { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Type { get; set; }
        [DataMember]
        public String Metadata { get; set; }
        [DataMember]
        public Double Lat { get; set; }
        [DataMember]
        public Double Long { get; set; }
        [DataMember]
        public Double Altitude { get; set; }
        [DataMember]
        public String LocationDescription { get; set; }
        [DataMember]
        public String CameraGUID { get; set; }
        [DataMember]
        public long? NvrId { get; set; }
        [DataMember]
        public String IPAddress { get; set; }
        [DataMember]
        public int Port { get; set; }
        //[DataMember]
       // public SiteDto Site { get; set; }
        [DataMember]
        public bool ActiveAlert { get; set; }
        [DataMember]
        public int InterfaceId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool? IsMovable { get; set; }

        [DataMember]
        public int? AssociatedDeviceId { get; set; }

        [DataMember]
        public String CameraAttachedDateTime { get; set; }

       /* [DataMember]
        public List<DeviceVAnalyticsScheduleDTO> DeviceVAnalyticsSchedule { get; set; }*/
        [DataMember]
        public List<SubMemberDTO> Submember { get; set; }
        
    }
}
