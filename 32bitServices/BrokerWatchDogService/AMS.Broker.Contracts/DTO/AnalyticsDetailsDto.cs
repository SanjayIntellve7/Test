using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Broker.Contracts.DTO
{
    // trupti 26 May 15


    [DataContract]
    public class AnalyticsDetailsDto
    {
        [DataMember]
        public Int64 DeviceId { get; set; }

        [DataMember]
        public string CameraGUID { get; set; }

        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public string AnalyticsServerIp { get; set; }

        [DataMember]
        public string AnalyticsName { get; set; }

        [DataMember()]
        public string ScheduleEnable { get; set; }

        [DataMember]
        public Nullable<Boolean> Status { get; set; }

        [DataMember]
        public int? SiteId { get; set; }

        [DataMember]
        public int? ZoneId { get; set; }

        [DataMember]
        public string Zone { get; set; }

        [DataMember]
        public string Site { get; set; }

        [DataMember]
        public Nullable<Boolean> AnalyticsStatus { get; set; }

        [DataMember]
        public Nullable<DateTime> AnalyticsStartTime { get; set; }

    }
}
