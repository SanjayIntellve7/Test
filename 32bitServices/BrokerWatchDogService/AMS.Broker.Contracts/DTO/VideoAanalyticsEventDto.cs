﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/07/08 - 12:22:06
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
    public partial class VideoAanalyticsEventDTO
    {
        [DataMember()]
        public Int32 VideoAanalyticsEventId { get; set; }

        [DataMember()]
        public Int32 DirectionFlg { get; set; }

        [DataMember()]
        public Guid CameraGuid { get; set; }

        [DataMember()]
        public String ObjectId { get; set; }

      ///  [DataMember()]
      //  public String CamIp { get; set; }

        [DataMember()]
        public Int32 Height { get; set; }

        [DataMember()]
        public Int32 Width { get; set; }

        [DataMember()]
        public Int32 CenterX { get; set; }

        [DataMember()]
        public Int32 CenterY { get; set; }

        [DataMember()]
        public DateTime SentTime { get; set; }

        [DataMember()]
        public Boolean IsInZone { get; set; }

        [DataMember()]
        public Int32 AlarmLevel { get; set; }

        [DataMember()]
        public String AlgorithmName { get; set; }

        [DataMember()]
        public long AlertId { get; set; }

        [DataMember()]
        public Int32 LaneNumber { get; set; }

        [DataMember()]
        public Int32 VehicleType { get; set; }

        [DataMember()]
        public Int32 VehicleCount { get; set; }
    }
}
