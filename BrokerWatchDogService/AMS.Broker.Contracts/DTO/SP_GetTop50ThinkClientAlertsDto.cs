using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class SP_GetTop50ThinkClientAlertsDto
    {
        [DataMember()]
        public Int64 AAlertID { get; set; }

        [DataMember()]
        public Nullable<Int64> ADeviceID { get; set; }

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
        public String AlertContext { get; set; }

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
        public Int64 IAlertID { get; set; }

        [DataMember()]
        public String SenderName { get; set; }

        [DataMember()]
        public String Headline { get; set; }

        [DataMember()]
        public String IDescription { get; set; }

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
        public Int32 ARSiteID { get; set; }

        [DataMember()]
        public Int64 ARInfoID { get; set; }

        [DataMember()]
        public Nullable<Double> Latitude { get; set; }

        [DataMember()]
        public Nullable<Double> Longitude { get; set; }

        [DataMember()]
        public Nullable<Double> ARAltitude { get; set; }

        [DataMember()]
        public String ARDescription { get; set; }

        [DataMember()]
        public Nullable<Int32> AlarmLevel { get; set; }

        [DataMember()]
        public Nullable<Int64> VAlertID { get; set; }

        [DataMember()]
        public String AlgorithmName { get; set; }

        [DataMember()]
        public Nullable<Guid> VCameraGuid { get; set; }

        [DataMember()]
        public Nullable<Int32> CenterX { get; set; }

        [DataMember()]
        public Nullable<Int32> CenterY { get; set; }

        [DataMember()]
        public Nullable<Int32> VHeight { get; set; }

        [DataMember()]
        public Nullable<DateTime> SentTime { get; set; }

        [DataMember()]
        public Nullable<Int32> VideoAanalyticsEventId { get; set; }

        [DataMember()]
        public Nullable<Int32> VWidth { get; set; }

        [DataMember()]
        public String ObjectId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsInZone { get; set; }

        [DataMember()]
        public Int64 DDeviceID { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String DDescription { get; set; }

        [DataMember()]
        public String Metadata { get; set; }

        [DataMember()]
        public String Type { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public Double DAltitude { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public String DCameraGuid { get; set; }

        [DataMember()]
        public Nullable<Int64> NvrId { get; set; }

        [DataMember()]
        public Nullable<Int32> DSiteID { get; set; }

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
        public Nullable<Int32> NWidth { get; set; }

        [DataMember()]
        public Nullable<Int32> NHeight { get; set; }

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
        public Int32 NvrCamera { get; set; }

        public SP_GetTop50ThinkClientAlertsDto()
        {
        }

        public SP_GetTop50ThinkClientAlertsDto(Int64 aAlertID, Nullable<Int64> aDeviceID, String sender, String source, DateTime sent, String messageTypeId, String code, String alertContext, String severityId, Nullable<DateTime> receivedDateTime, String note, String incidents, Nullable<Guid> membershipUserId, String alertOwner, String alertzone, Int64 infoId, Int64 iAlertID, String senderName, String headline, String iDescription, String instruction, String urgencyID, String certaintyId, String event_, Int32 areaId, Int32 aRSiteID, Int64 aRInfoID, Nullable<Double> latitude, Nullable<Double> longitude, Nullable<Double> aRAltitude, String aRDescription, Nullable<Int32> alarmLevel, Nullable<Int64> vAlertID, String algorithmName, Nullable<Guid> vCameraGuid, Nullable<Int32> centerX, Nullable<Int32> centerY, Nullable<Int32> vHeight, Nullable<DateTime> sentTime, Nullable<Int32> videoAanalyticsEventId, Nullable<Int32> vWidth, String objectId, Nullable<Boolean> isInZone, Int64 dDeviceID, String externalId, String dDescription, String metadata, String type, Double lat, Double long_, Double dAltitude, String locationDescription, String dCameraGuid, Nullable<Int64> nvrId, Nullable<Int32> dSiteID, Nullable<Int32> interfaceId, Nullable<Boolean> isMovable, String name, Nullable<Int32> analyticAlgorithmTypeId, Nullable<Int32> fPS, Nullable<Int32> maxBlobSize, Nullable<Int32> minBlobSize, Nullable<Int32> alarmDelay, Nullable<Decimal> updateRate, Nullable<Int32> nWidth, Nullable<Int32> nHeight, Byte[] zoneData, Nullable<Int32> analyticsEventTemplateId, Nullable<Boolean> isPtz, String cameraIp, Nullable<Int32> directionflag, String cameraUrl, String camUser, String camPassword, String cameraPort, Nullable<Int32> cameraType, Nullable<Int32> maxBlobHeight, Nullable<Int32> maxBlobWidth, Nullable<Int32> minBlobHeight, Nullable<Int32> minBlobWidth, String analyticsServerIp, Nullable<Int32> lane1, Nullable<Int32> lane2, Nullable<Int32> lane3, Nullable<Int32> noOfLens, Nullable<Int32> chanelNo, Nullable<Int32> isEdgeAnalytics, String iPAddress, Int32 nvrCamera)
        {
            this.AAlertID = aAlertID;
            this.ADeviceID = aDeviceID;
            this.Sender = sender;
            this.Source = source;
            this.Sent = sent;
            this.MessageTypeId = messageTypeId;
            this.code = code;
            this.AlertContext = alertContext;
            this.SeverityId = severityId;
            this.ReceivedDateTime = receivedDateTime;
            this.Note = note;
            this.Incidents = incidents;
            this.MembershipUserId = membershipUserId;
            this.AlertOwner = alertOwner;
            this.Alertzone = alertzone;
            this.InfoId = infoId;
            this.IAlertID = iAlertID;
            this.SenderName = senderName;
            this.Headline = headline;
            this.IDescription = iDescription;
            this.Instruction = instruction;
            this.UrgencyID = urgencyID;
            this.CertaintyId = certaintyId;
            this.Event_ = event_;
            this.AreaId = areaId;
            this.ARSiteID = aRSiteID;
            this.ARInfoID = aRInfoID;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.ARAltitude = aRAltitude;
            this.ARDescription = aRDescription;
            this.AlarmLevel = alarmLevel;
            this.VAlertID = vAlertID;
            this.AlgorithmName = algorithmName;
            this.VCameraGuid = vCameraGuid;
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.VHeight = vHeight;
            this.SentTime = sentTime;
            this.VideoAanalyticsEventId = videoAanalyticsEventId;
            this.VWidth = vWidth;
            this.ObjectId = objectId;
            this.IsInZone = isInZone;
            this.DDeviceID = dDeviceID;
            this.ExternalId = externalId;
            this.DDescription = dDescription;
            this.Metadata = metadata;
            this.Type = type;
            this.Lat = lat;
            this.Long_ = long_;
            this.DAltitude = dAltitude;
            this.LocationDescription = locationDescription;
            this.DCameraGuid = dCameraGuid;
            this.NvrId = nvrId;
            this.DSiteID = dSiteID;
            this.InterfaceId = interfaceId;
            this.IsMovable = isMovable;
            this.Name = name;
            this.AnalyticAlgorithmTypeId = analyticAlgorithmTypeId;
            this.FPS = fPS;
            this.MaxBlobSize = maxBlobSize;
            this.MinBlobSize = minBlobSize;
            this.AlarmDelay = alarmDelay;
            this.UpdateRate = updateRate;
            this.NWidth = nWidth;
            this.NHeight = nHeight;
            this.ZoneData = zoneData;
            this.AnalyticsEventTemplateId = analyticsEventTemplateId;
            this.IsPtz = isPtz;
            this.CameraIp = cameraIp;
            this.directionflag = directionflag;
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
            this.NvrCamera = nvrCamera;
        }
    }
}
