//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/07/08 - 12:22:05
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
    public partial class EventDTO
    {
        [DataMember()]
        public Int32 EventId { get; set; }

        [DataMember()]
        public Int64 DeviceId { get; set; }

        [DataMember()]
        public Nullable<Int64> PanelAccountId { get; set; }

        [DataMember()]
        public String EventCode { get; set; }

        [DataMember()]
        public DateTime TimeSent { get; set; }

        [DataMember()]
        public String ExternalMessage { get; set; }

        [DataMember()]
        public Nullable<Int32> AreaId { get; set; }

        [DataMember()]
        public Nullable<Int64> AlertId { get; set; }

        [DataMember()]
        public Nullable<Int32> FrameTypeCode { get; set; }

        [DataMember()]
        public Nullable<Int32> FrameId { get; set; }

        [DataMember()]
        public String Qualifier { get; set; }

        [DataMember()]
        public String ZoneCode { get; set; }

        [DataMember()]
        public String LineCode { get; set; }

        [DataMember()]
        public String DriverName { get; set; }

        [DataMember()]
        public String DriverPortNumber { get; set; }

        [DataMember()]
        public String EventDevID { get; set; }

        [DataMember()]
        public String ZoneSubsystem { get; set; }

        public EventDTO()
        {
        }

        public EventDTO(Int32 eventId, Int64 deviceId, Nullable<Int64> panelAccountId, String eventCode, DateTime timeSent, String externalMessage, Nullable<Int32> areaId, Nullable<Int64> alertId, Nullable<Int32> frameTypeCode, Nullable<Int32> frameId, String qualifier, String zoneCode, String lineCode, String driverName, String driverPortNumber, String eventDevID, String zoneSubsystem)
        {
			this.EventId = eventId;
			this.DeviceId = deviceId;
			this.PanelAccountId = panelAccountId;
			this.EventCode = eventCode;
			this.TimeSent = timeSent;
			this.ExternalMessage = externalMessage;
			this.AreaId = areaId;
			this.AlertId = alertId;
			this.FrameTypeCode = frameTypeCode;
			this.FrameId = frameId;
			this.Qualifier = qualifier;
			this.ZoneCode = zoneCode;
			this.LineCode = lineCode;
			this.DriverName = driverName;
			this.DriverPortNumber = driverPortNumber;
			this.EventDevID = eventDevID;
			this.ZoneSubsystem = zoneSubsystem;
        }
    }
}
