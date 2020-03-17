using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SurveillanceDeviceDashboard_ResultDTO
    {
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
        public Double Altitude { get; set; }

        [DataMember()]
        public String LocationDescription { get; set; }

        [DataMember()]
        public String CameraGuid { get; set; }

        [DataMember()]
        public Nullable<Int64> NvrId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        [DataMember()]
        public Boolean ActiveAlert { get; set; }

        [DataMember()]
        public Nullable<Boolean> HasPvAnalytics { get; set; }

        [DataMember()]
        public Nullable<Boolean> HasSzAnalytics { get; set; }

        [DataMember()]
        public Nullable<Boolean> HasAbAnalytics { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceId { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsMovable { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> StatusDateTime { get; set; }

        [DataMember()]
        public String StatusDescription { get; set; }

        [DataMember()]
        public String DeviceStatusType { get; set; }

        public SP_SurveillanceDeviceDashboard_ResultDTO()
        {
        }

        public SP_SurveillanceDeviceDashboard_ResultDTO(Int64 deviceId, String externalId, String description, String metadata, String type, Double lat, Double long_, Double altitude, String locationDescription, String cameraGuid, Nullable<Int64> nvrId, Nullable<Int32> siteId, Boolean activeAlert, Nullable<Boolean> hasPvAnalytics, Nullable<Boolean> hasSzAnalytics, Nullable<Boolean> hasAbAnalytics, Nullable<Int32> interfaceId, Nullable<Boolean> isMovable, String name, Nullable<Int32> deviceStatus, Nullable<DateTime> statusDateTime, String statusDescription, String deviceStatusType)
        {
            this.DeviceId = deviceId;
            this.ExternalId = externalId;
            this.Description = description;
            this.Metadata = metadata;
            this.Type = type;
            this.Lat = lat;
            this.Long_ = long_;
            this.Altitude = altitude;
            this.LocationDescription = locationDescription;
            this.CameraGuid = cameraGuid;
            this.NvrId = nvrId;
            this.SiteId = siteId;
            this.ActiveAlert = activeAlert;
            this.HasPvAnalytics = hasPvAnalytics;
            this.HasSzAnalytics = hasSzAnalytics;
            this.HasAbAnalytics = hasAbAnalytics;
            this.InterfaceId = interfaceId;
            this.IsMovable = isMovable;
            this.Name = name;
            this.DeviceStatus = deviceStatus;
            this.StatusDateTime = statusDateTime;
            this.StatusDescription = statusDescription;
            this.DeviceStatusType = deviceStatusType;
        }

    }
}
