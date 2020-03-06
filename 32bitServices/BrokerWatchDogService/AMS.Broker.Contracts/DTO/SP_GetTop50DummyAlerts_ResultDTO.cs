//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/19 - 18:57:14
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
    public partial class SP_GetTop50DummyAlerts_ResultDTO
    {
        [DataMember()]
        public Int64 AlertID { get; set; }

        [DataMember()]
        public Nullable<Int64> DeviceId { get; set; }

        [DataMember()]
        public String Sender { get; set; }

        [DataMember()]
        public String Source { get; set; }

        [DataMember()]
        public DateTime Sent { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        [DataMember()]
        public String code { get; set; }

        [DataMember()]
        public String SeverityId { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDateTime { get; set; }

        [DataMember()]
        public String Note { get; set; }

        [DataMember()]
        public String Incidents { get; set; }

        [DataMember()]
        public Nullable<Guid> MembershipUserId { get; set; }

        [DataMember()]
        public String AlertOwner { get; set; }

        [DataMember()]
        public String Alertzone { get; set; }

        [DataMember()]
        public Int64 InfoId { get; set; }

        [DataMember()]
        public Int64 AlertId1 { get; set; }

        [DataMember()]
        public String SenderName { get; set; }

        [DataMember()]
        public String Headline { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public String Instruction { get; set; }

        [DataMember()]
        public String UrgencyID { get; set; }

        [DataMember()]
        public String CertaintyId { get; set; }

        [DataMember()]
        public String Event_ { get; set; }

        [DataMember()]
        public Int32 AreaId { get; set; }

        [DataMember()]
        public Int32 SiteId { get; set; }

        [DataMember()]
        public Int64 InfoId1 { get; set; }

        [DataMember()]
        public Nullable<Double> Latitude { get; set; }

        [DataMember()]
        public Nullable<Double> Longitude { get; set; }

        [DataMember()]
        public Nullable<Double> Altitude { get; set; }

        [DataMember()]
        public String Description1 { get; set; }

        [DataMember()]
        public Nullable<Int32> AlarmLevel { get; set; }

        [DataMember()]
        public Nullable<Int64> AlertId2 { get; set; }

        [DataMember()]
        public String AlgorithmName { get; set; }

        [DataMember()]
        public Nullable<Guid> CameraGuid { get; set; }

        [DataMember()]
        public Nullable<Int32> CenterX { get; set; }

        [DataMember()]
        public Nullable<Int32> CenterY { get; set; }

        [DataMember()]
        public Nullable<Int32> Height { get; set; }

        [DataMember()]
        public Nullable<DateTime> SentTime { get; set; }

        [DataMember()]
        public Nullable<Int32> VideoAanalyticsEventId { get; set; }

        [DataMember()]
        public Nullable<Int32> Width { get; set; }

        [DataMember()]
        public String ObjectId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsInZone { get; set; }

        [DataMember()]
        public Int64 deviceID1 { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String Description2 { get; set; }

        [DataMember()]
        public String Metadata { get; set; }

        [DataMember()]
        public String Type { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public Double Altitude1 { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public String CameraGuid1 { get; set; }

        [DataMember()]
        public Nullable<Int64> NvrId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteID1 { get; set; }

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
        public Nullable<Int32> Width1 { get; set; }

        [DataMember()]
        public Nullable<Int32> Height1 { get; set; }

        [DataMember()]
        public Byte[] ZoneData { get; set; }

        [DataMember()]
        public Nullable<Int32> AnalyticsEventTemplateId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsPtz { get; set; }

        [DataMember()]
        public String CameraIp { get; set; }

        [DataMember()]
        public Nullable<Int32> directionflag { get; set; }

        [DataMember()]
        public String CameraUrl { get; set; }

        [DataMember()]
        public String CamUser { get; set; }

        [DataMember()]
        public String CamPassword { get; set; }

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

        public SP_GetTop50DummyAlerts_ResultDTO()
        {
        }

        public SP_GetTop50DummyAlerts_ResultDTO(Int64 alertID, Nullable<Int64> deviceId, String sender, String source, DateTime sent, String messageTypeId, String code, String severityId, Nullable<DateTime> receivedDateTime, String note, String incidents, Nullable<Guid> membershipUserId, String alertOwner, String alertzone, Int64 infoId, Int64 alertId1, String senderName, String headline, String description, String instruction, String urgencyID, String certaintyId, String event_, Int32 areaId, Int32 siteId, Int64 infoId1, Nullable<Double> latitude, Nullable<Double> longitude, Nullable<Double> altitude, String description1, Nullable<Int32> alarmLevel, Nullable<Int64> alertId2, String algorithmName, Nullable<Guid> cameraGuid, Nullable<Int32> centerX, Nullable<Int32> centerY, Nullable<Int32> height, Nullable<DateTime> sentTime, Nullable<Int32> videoAanalyticsEventId, Nullable<Int32> width, String objectId, Nullable<Boolean> isInZone, Int64 deviceID1, String externalId, String description2, String metadata, String type, Double lat, Double long_, Double altitude1, String locationDescription, String cameraGuid1, Nullable<Int64> nvrId, Nullable<Int32> siteID1, Nullable<Int32> interfaceId, Nullable<Boolean> isMovable, String name, Nullable<Int32> analyticAlgorithmTypeId, Nullable<Int32> fPS, Nullable<Int32> maxBlobSize, Nullable<Int32> minBlobSize, Nullable<Int32> alarmDelay, Nullable<Decimal> updateRate, Nullable<Int32> width1, Nullable<Int32> height1, Byte[] zoneData, Nullable<Int32> analyticsEventTemplateId, Nullable<Boolean> isPtz, String cameraIp, Nullable<Int32> directionflag, String cameraUrl, String camUser, String camPassword, Nullable<Int32> cameraType, Nullable<Int32> maxBlobHeight, Nullable<Int32> maxBlobWidth, Nullable<Int32> minBlobHeight, Nullable<Int32> minBlobWidth, String analyticsServerIp, Nullable<Int32> lane1, Nullable<Int32> lane2, Nullable<Int32> lane3, Nullable<Int32> noOfLens, Nullable<Int32> chanelNo, Nullable<Int32> isEdgeAnalytics, String iPAddress)
        {
			this.AlertID = alertID;
			this.DeviceId = deviceId;
			this.Sender = sender;
			this.Source = source;
			this.Sent = sent;
			this.MessageTypeId = messageTypeId;
			this.code = code;
			this.SeverityId = severityId;
			this.ReceivedDateTime = receivedDateTime;
			this.Note = note;
			this.Incidents = incidents;
			this.MembershipUserId = membershipUserId;
			this.AlertOwner = alertOwner;
			this.Alertzone = alertzone;
			this.InfoId = infoId;
			this.AlertId1 = alertId1;
			this.SenderName = senderName;
			this.Headline = headline;
			this.Description = description;
			this.Instruction = instruction;
			this.UrgencyID = urgencyID;
			this.CertaintyId = certaintyId;
			this.Event_ = event_;
			this.AreaId = areaId;
			this.SiteId = siteId;
			this.InfoId1 = infoId1;
			this.Latitude = latitude;
			this.Longitude = longitude;
			this.Altitude = altitude;
			this.Description1 = description1;
			this.AlarmLevel = alarmLevel;
			this.AlertId2 = alertId2;
			this.AlgorithmName = algorithmName;
			this.CameraGuid = cameraGuid;
			this.CenterX = centerX;
			this.CenterY = centerY;
			this.Height = height;
			this.SentTime = sentTime;
			this.VideoAanalyticsEventId = videoAanalyticsEventId;
			this.Width = width;
			this.ObjectId = objectId;
			this.IsInZone = isInZone;
			this.deviceID1 = deviceID1;
			this.ExternalId = externalId;
			this.Description2 = description2;
			this.Metadata = metadata;
			this.Type = type;
			this.Lat = lat;
			this.Long_ = long_;
			this.Altitude1 = altitude1;
			this.LocationDescription = locationDescription;
			this.CameraGuid1 = cameraGuid1;
			this.NvrId = nvrId;
			this.SiteID1 = siteID1;
			this.InterfaceId = interfaceId;
			this.IsMovable = isMovable;
			this.Name = name;
			this.AnalyticAlgorithmTypeId = analyticAlgorithmTypeId;
			this.FPS = fPS;
			this.MaxBlobSize = maxBlobSize;
			this.MinBlobSize = minBlobSize;
			this.AlarmDelay = alarmDelay;
			this.UpdateRate = updateRate;
			this.Width1 = width1;
			this.Height1 = height1;
			this.ZoneData = zoneData;
			this.AnalyticsEventTemplateId = analyticsEventTemplateId;
			this.IsPtz = isPtz;
			this.CameraIp = cameraIp;
			this.directionflag = directionflag;
			this.CameraUrl = cameraUrl;
			this.CamUser = camUser;
			this.CamPassword = camPassword;
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
        }
    }
}
