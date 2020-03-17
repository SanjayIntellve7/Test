using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class NvrCameraDto : DeviceDto
    {
        [DataMember]
        public int? FPS { get; set; }

        

        [DataMember]
        public int AnalyticAlgorithmTypeId { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int? MaxBlobSize { get; set; }

        [DataMember]
        public int? MinBlobSize { get; set; }

        [DataMember]
        public int? AlarmDelay { get; set; }

        [DataMember]
        public decimal? UpdateRate { get; set; }

        [DataMember]
        public int? Width { get; set; }

        [DataMember]
        public String CameraIp { get; set; }

        [DataMember]
        public bool? IsPtz { get; set; }
               
        [DataMember]
        public int? Height { get; set; }

        [DataMember]
        public int? MaxBlobWidth { get; set; }

        [DataMember]
        public int? MaxBlobHeight { get; set; }

        [DataMember]
        public int? MinBlobWidth { get; set; }

        [DataMember]
        public int? MinBlobHeight { get; set; }
              
        [DataMember]
        public int? ZoneRows { get; set; }

        [DataMember]
        public int? CameraType { get; set; }

        [DataMember]
        public int? ZoneColumns { get; set; }

        [DataMember]
        public byte[] ZoneData { get; set; }

        [DataMember]
        public int? AnalyticsEventTemplateId { get; set; }

        [DataMember]
        public AnalyticAlgorithmTypeDto AnalyticAlgorithmType { get; set; }

        [DataMember]
        public string LineStart { get; set; }

        [DataMember]
        public string LineEnd { get; set; }

        [DataMember]
        public int? DirectionFlag { get; set; }

        [DataMember]
        public string CameraUrl { get; set; }
        [DataMember]
        public string CameraPort { get; set; }

        [DataMember]
        public string CamUser { get; set; }

        [DataMember]
        public string CamPassword { get; set; }

        [DataMember]
        public String AnalyticsServerIp { get; set; }

        [DataMember]
        public int? Lane1 { get; set; }

        [DataMember]
        public int? Lane2 { get; set; }

        [DataMember]
        public int? Lane3 { get; set; }

        [DataMember]
        public int? NoOfLens { get; set; }

        [DataMember]                        //trupti160116
        public int? ChanelNo { get; set; }

        [DataMember]                        //amit 27 Jan 16
        public int? IsEdgeAnalytics { get; set; }      

        [DataMember]
        public String MediaType { get; set; }

        [DataMember]
        public string RTSPCameraUrl { get; set; }

        [DataMember]
        public int? ObjectTrackingTime { get; set; }

        [DataMember]
        public int? PeopleCrowdThreashold { get; set; }
      
    }
}
