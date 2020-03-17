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
        public bool? IsCameraDevice { get; set; }
        [DataMember]
        public bool? IsNonCameraDevice { get; set; }

        [DataMember]
        public int? AssociatedDeviceId { get; set; }

        [DataMember]
        public String CameraAttachedDateTime { get; set; }

        /* [DataMember]
         public List<DeviceVAnalyticsScheduleDTO> DeviceVAnalyticsSchedule { get; set; }*/
        [DataMember]
        public List<SubMemberDTO> Submember { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }

        [DataMember]
        public string SiteName { get; set; } //amit 19062017

        [DataMember]
        public string ZoneName { get; set; }  //amit 19062017

        [DataMember]
        public bool IsNvrCamera { get; set; }  //amit 19062017

        [DataMember]
        public int LiveView { get; set; }//amit 19062017

        [DataMember]
        public int PlaybackView { get; set; }//amit 19062017

        [DataMember]
        public int RecordingExport { get; set; }//amit 19062017      

        [DataMember]
        public int PTZControl { get; set; }//amit 19062017

        [DataMember]
        public int NonCamView { get; set; }//amit 19062017

        [DataMember]
        public int NonCamControl { get; set; }//amit 19062017

        [DataMember]
        public bool? IsDeviceChecked { get; set; } //amit 19062017

        [DataMember]
        public bool? ShowPtzControlCheck { get; set; } //amit 19062017

        [DataMember]
        public String InterafaceType { get; set; } //this is for interface type

        [DataMember]
        public String StreamingUrl { get; set; }

        [DataMember]
        public string SenderStationName { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public Int32 AccountId { get; set; }

        [DataMember]
        public Int32 ARSiteID { get; set; }

        [DataMember]
        public string ARName { get; set; }

        [DataMember]
        public Int32 FLSiteID { get; set; }

        [DataMember]
        public Int32 ZNSiteID { get; set; }

        [DataMember]
        public string FLName { get; set; }

        [DataMember]
        public Int32 InterafaceSubTypeID { get; set; }

        [DataMember]
        public string InterafaceSubType { get; set; }

        [DataMember]
        public string OperationsAccess { get; set; }

        //  [DataMember]
        //   public String MediaUrl { get; set; } //this is for different media url

    }
}
