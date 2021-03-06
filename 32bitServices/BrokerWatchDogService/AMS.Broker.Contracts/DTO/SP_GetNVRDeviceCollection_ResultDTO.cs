//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/19 - 18:53:59
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetNVRDeviceCollection_ResultDTO
    {
        [DataMember()]
        public String SiteName { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public Int64 DeviceId { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public String Metadata { get; set; }

        [DataMember()]
        public String Type { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public String CameraGuid { get; set; }

        [DataMember()]
        public Nullable<Int64> NvrId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsMovable { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Nullable<Int32> AnalyticAlgorithmTypeId { get; set; }

        [DataMember()]
        public Nullable<Int32> FPS { get; set; }

        [DataMember()]
        public Nullable<Int32> MaxBlobSize { get; set; }

        [DataMember()]
        public Nullable<Int32> MinBlobSize { get; set; }

        [DataMember()]
        public Nullable<Int32> AlarmDelay { get; set; }

        [DataMember()]
        public Nullable<Decimal> UpdateRate { get; set; }

        [DataMember()]
        public Nullable<Int32> Width { get; set; }

        [DataMember()]
        public Nullable<Int32> Height { get; set; }

        [DataMember()]
        public Byte[] ZoneData { get; set; }

        [DataMember()]
        public Nullable<Int32> AnalyticsEventTemplateId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsPtz { get; set; }

        [DataMember()]
        public String CameraIp { get; set; }

        [DataMember()]
        public Nullable<Int32> DirectionFlag { get; set; }

        [DataMember()]
        public String CameraUrl { get; set; }

        [DataMember()]
        public String CamUser { get; set; }

        [DataMember()]
        public String CamPassword { get; set; }

        [DataMember()]
        public String CameraPort { get; set; }    

        [DataMember()]
        public Nullable<Int32> CameraType { get; set; }

        [DataMember()]
        public Nullable<Int32> MaxBlobHeight { get; set; }

        [DataMember()]
        public Nullable<Int32> MaxBlobWidth { get; set; }

        [DataMember()]
        public Nullable<Int32> MinBlobHeight { get; set; }

        [DataMember()]
        public Nullable<Int32> MinBlobWidth { get; set; }

        [DataMember()]
        public String AnalyticsServerIp { get; set; }

        [DataMember()]
        public Nullable<Int32> Lane1 { get; set; }

        [DataMember()]
        public Nullable<Int32> Lane2 { get; set; }

        [DataMember()]
        public Nullable<Int32> Lane3 { get; set; }

        [DataMember()]
        public Nullable<Int32> NoOfLens { get; set; }

        [DataMember()]
        public Nullable<Int32> ChanelNo { get; set; }

        [DataMember()]
        public Nullable<Int32> IsEdgeAnalytics { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public Nullable<Boolean> LiveView { get; set; }

        [DataMember()]
        public Nullable<Boolean> PlaybackView { get; set; }

        [DataMember()]
        public Nullable<Boolean> RecordingExport { get; set; }

        [DataMember()]
        public Nullable<Boolean> PTZControl { get; set; }

        [DataMember()]
        public Nullable<Boolean> NonCamView { get; set; }

        [DataMember()]
        public Nullable<Boolean> NonCamControl { get; set; }

        [DataMember()]
        public Int32 NvrCamera { get; set; }

        [DataMember()]
        public String InterafaceType { get; set; }

        public SP_GetNVRDeviceCollection_ResultDTO()
        {
        }

        public SP_GetNVRDeviceCollection_ResultDTO(String siteName, String zoneName, Int64 deviceId, String externalId, String description, String metadata, String type, Double lat, Double long_, String locationDescription, String cameraGuid, Nullable<Int64> nvrId, Nullable<Int32> siteId, Nullable<Int32> interfaceId, Nullable<Boolean> isMovable, String name, Nullable<Int32> analyticAlgorithmTypeId, Nullable<Int32> fPS, Nullable<Int32> maxBlobSize, Nullable<Int32> minBlobSize, Nullable<Int32> alarmDelay, Nullable<Decimal> updateRate, Nullable<Int32> width, Nullable<Int32> height, Byte[] zoneData, Nullable<Int32> analyticsEventTemplateId, Nullable<Boolean> isPtz, String cameraIp, Nullable<Int32> directionFlag, String cameraUrl, String camUser, String camPassword, String cameraPort, Nullable<Int32> cameraType, Nullable<Int32> maxBlobHeight, Nullable<Int32> maxBlobWidth, Nullable<Int32> minBlobHeight, Nullable<Int32> minBlobWidth, String analyticsServerIp, Nullable<Int32> lane1, Nullable<Int32> lane2, Nullable<Int32> lane3, Nullable<Int32> noOfLens, Nullable<Int32> chanelNo, Nullable<Int32> isEdgeAnalytics, String iPAddress, Nullable<Boolean> liveView, Nullable<Boolean> playbackView, Nullable<Boolean> recordingExport, Nullable<Boolean> pTZControl, Nullable<Boolean> nonCamView, Nullable<Boolean> nonCamControl, Int32 nvrCamera, String interafaceType)
        {
			this.SiteName = siteName;
			this.ZoneName = zoneName;
			this.DeviceId = deviceId;
			this.ExternalId = externalId;
			this.Description = description;
			this.Metadata = metadata;
			this.Type = type;
			this.Lat = lat;
			this.Long_ = long_;
			this.LocationDescription = locationDescription;
			this.CameraGuid = cameraGuid;
			this.NvrId = nvrId;
			this.SiteId = siteId;
			this.InterfaceId = interfaceId;
			this.IsMovable = isMovable;
			this.Name = name;
			this.AnalyticAlgorithmTypeId = analyticAlgorithmTypeId;
			this.FPS = fPS;
			this.MaxBlobSize = maxBlobSize;
			this.MinBlobSize = minBlobSize;
			this.AlarmDelay = alarmDelay;
			this.UpdateRate = updateRate;
			this.Width = width;
			this.Height = height;
			this.ZoneData = zoneData;
			this.AnalyticsEventTemplateId = analyticsEventTemplateId;
			this.IsPtz = isPtz;
			this.CameraIp = cameraIp;
			this.DirectionFlag = directionFlag;
			this.CameraUrl = cameraUrl;
			this.CamUser = camUser;
			this.CamPassword = camPassword;
			this.CameraPort = cameraPort;
			this.CameraType = cameraType;
			this.MaxBlobHeight = maxBlobHeight;
			this.MaxBlobWidth = maxBlobWidth;
			this.MinBlobHeight = minBlobHeight;
			this.MinBlobWidth = minBlobWidth;
			this.AnalyticsServerIp = analyticsServerIp;
			this.Lane1 = lane1;
			this.Lane2 = lane2;
			this.Lane3 = lane3;
			this.NoOfLens = noOfLens;
			this.ChanelNo = chanelNo;
			this.IsEdgeAnalytics = isEdgeAnalytics;
			this.IPAddress = iPAddress;
			this.LiveView = liveView;
			this.PlaybackView = playbackView;
            this.RecordingExport = recordingExport;
			this.PTZControl = pTZControl;
			this.NonCamView = nonCamView;
			this.NonCamControl = nonCamControl;
			this.NvrCamera = nvrCamera;
            this.InterafaceType = interafaceType;
        }
    }
}
