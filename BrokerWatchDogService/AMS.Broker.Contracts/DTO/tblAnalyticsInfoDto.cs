using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(tblAnalyticsInfoDto))]
    public sealed class tblAnalyticsInfoDto
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public Int64 DeviceID { get; set; }

        [DataMember]
        public string AnalyticsServerIp { get; set; }

        [DataMember]
        public int? ChanelNo { get; set; }

        [DataMember]
        public int AnalyticAlgorithmTypeId { get; set; }

        [DataMember]
        public int AnalyticsEventTemplateId { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int? MaxBlobSize { get; set; }

        [DataMember]
        public int? MinBlobSize { get; set; }

        [DataMember]
        public int? ZoneRows { get; set; }

        [DataMember]
        public int? ZoneColumns { get; set; }

        [DataMember]
        public int? DirectionFlag { get; set; }

        [DataMember]
        public string LineStart { get; set; }

        [DataMember]
        public string LineEnd { get; set; }

        [DataMember]
        public int? MaxBlobWidth { get; set; }

        [DataMember]
        public int? MaxBlobHeight { get; set; }

        [DataMember]
        public int? MinBlobWidth { get; set; }

        [DataMember]
        public int? MinBlobHeight { get; set; }

        [DataMember]
        public int? Lane1 { get; set; }

        [DataMember]
        public int? Lane2 { get; set; }

        [DataMember]
        public int? Lane3 { get; set; }

        [DataMember]
        public int? IsEdgeAnalytics { get; set; }

        [DataMember]
        public int? ObjectTrackingTime { get; set; }

        [DataMember]
        public int? PeopleCrowdThreashold { get; set; }

        [DataMember]
        public int? AlarmDelay { get; set; }

        [DataMember]
        public decimal UpdateRate { get; set; }

        [DataMember]
        public string RTSPCameraUrl { get; set; }

        [DataMember]
        public byte[] ZoneData { get; set; }
    

    }
}




