//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/15 - 20:00:27
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
    public partial class tbluserdeviceinfoDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Guid UserID { get; set; }

        [DataMember()]
        public Int32 SiteID { get; set; }

        [DataMember()]
        public Nullable<Int32> ZoneID { get; set; }

        [DataMember()]
        public Int32 DeviceID { get; set; }

        [DataMember()]
        public Boolean LiveView { get; set; }

        [DataMember()]
        public Boolean PlaybackView { get; set; }

        [DataMember()]
        public Boolean RecordingExport { get; set; }

        [DataMember()]
        public Boolean PTZControl { get; set; }

        [DataMember()]
        public Boolean NonCamView { get; set; }

        [DataMember()]
        public Boolean NonCamControl { get; set; }

        public tbluserdeviceinfoDTO()
        {
        }

        public tbluserdeviceinfoDTO(Int32 iD, Guid userID, Int32 siteID, Nullable<Int32> zoneID, Int32 deviceID, Boolean liveView, Boolean playbackView, Boolean recordingExport, Boolean pTZControl, Boolean nonCamView, Boolean nonCamControl)
        {
			this.ID = iD;
			this.UserID = userID;
			this.SiteID = siteID;
			this.ZoneID = zoneID;
			this.DeviceID = deviceID;
			this.LiveView = liveView;
			this.PlaybackView = playbackView;
			this.RecordingExport = recordingExport;
			this.PTZControl = pTZControl;
			this.NonCamView = nonCamView;
			this.NonCamControl = nonCamControl;
        }
    }
}