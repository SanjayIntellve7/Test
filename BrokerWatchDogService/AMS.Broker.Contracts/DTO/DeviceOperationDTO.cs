using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AMS.Broker.Contracts.DTO
{

    public class DeviceOperationDTO
    {

        [DataMember]
        public Int64 DeviceId { get; set; }

        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public String Type { get; set; }

        [DataMember]
        public long? NvrId { get; set; }

        [DataMember]
        public int InterfaceId { get; set; }

        [DataMember]
        public int SiteId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool? IsCameraDevice { get; set; }

        [DataMember]
        public bool? IsNonCameraDevice { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public string ZoneName { get; set; }

        [DataMember]
        public Int32 ZNSiteID { get; set; }

        [DataMember]
        public bool IsNvrCamera { get; set; }

        [DataMember]
        public int LiveView { get; set; }

        [DataMember]
        public int PlaybackView { get; set; }

        [DataMember]
        public int RecordingExport { get; set; }

        [DataMember]
        public int PTZControl { get; set; }

        [DataMember]
        public int NonCamView { get; set; }

        [DataMember]
        public int NonCamControl { get; set; }

        [DataMember]
        public bool? IsDeviceChecked { get; set; }

        [DataMember]
        public bool? ShowPtzControlCheck { get; set; }

        [DataMember]
        public String InterafaceType { get; set; }

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
        public string FLName { get; set; }


        [DataMember]
        public DataWithName OperationsData { get; set; }

        [DataMember]
        public bool IsDeviceEnable { get; set; }

    }

    [XmlRoot(ElementName = "Operation")]
    public class Operation
    {
        [XmlElement(ElementName = "lInterfaceOperationsID")]
        public string LInterfaceOperationsID { get; set; }

        [XmlElement(ElementName = "IsAllowed")]
        public string IsAllowed { get; set; }
    }

    public class OperationWithName
    {

        public int LInterfaceOperationsID { get; set; }

        public bool IsAllowed { get; set; }

        public string InterfaceOperationName { get; set; }

        public bool IsEnabled { get; set; }

        public int DeviceId { get; set; }

        public string IdCombination { get; set; }
    }

    [XmlRoot(ElementName = "Data")]
    public class Data
    {
        [XmlElement(ElementName = "Operation")]
        public List<Operation> Operation { get; set; }

    }


    public class DataWithName
    {
        public List<OperationWithName> OperationWithName { get; set; }
    }
}
