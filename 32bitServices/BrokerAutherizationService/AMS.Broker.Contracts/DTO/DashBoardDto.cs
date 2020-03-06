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
    public class DashBoardDto
    {
        [DataMember]
        public Int64 AlertID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ZoneName { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public DateTime? DataDateTime { get; set; }
        [DataMember]
        public string DeviceDesc { get; set; }
        [DataMember]
        public int? DeviceID { get; set; }
        [DataMember]
        public string DeviceName { get; set; }
        [DataMember]
        public string DType { get; set; }
        [DataMember]
        public DateTime? ICreateDate { get; set; }
        [DataMember]
        public int? IncidentReportID { get; set; }
        [DataMember]
        public string LocationDescription { get; set; }
        [DataMember]
        public int? SiteID { get; set; }

        [DataMember]
        public string AlertType { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string LocationName { get; set; }

        [DataMember]
        public int? DeviceCount { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string MessageTypeId { get; set; }

        [DataMember]
        public string Resv1 { get; set; }
        [DataMember]
        public string Resv2 { get; set; }
        [DataMember]
        public string Resv3 { get; set; }
        [DataMember]
        public string Resv4 { get; set; }
        [DataMember]
        public string Resv5 { get; set; }
        [DataMember]
        public string Resv6 { get; set; }
        [DataMember]
        public string Resv7 { get; set; }
        [DataMember]
        public string Resv8 { get; set; }
        [DataMember]
        public string Resv9 { get; set; }
        [DataMember]
        public string Res10 { get; set; }

        [DataMember]
        public Int64 AlertCount { get; set; }

        public DashBoardDto()
        {

        }
    }
}

