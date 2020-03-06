﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2018/01/15 - 16:16:11
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
    public partial class tblVehicleTrackingDataDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Location { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public String Speed { get; set; }

        [DataMember()]
        public String Updated { get; set; }

        [DataMember()]
        public String Veh_reg { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDateTime { get; set; }

        [DataMember()]
        public String Resv1 { get; set; }

        [DataMember()]
        public String Resv2 { get; set; }

        [DataMember()]
        public String Resv3 { get; set; }

        public tblVehicleTrackingDataDTO()
        {
        }

        public tblVehicleTrackingDataDTO(Int64 iD, String latitude, String location, String longitude, String speed, String updated, String veh_reg, Nullable<DateTime> receivedDateTime, String resv1, String resv2, String resv3)
        {
            this.ID = iD;
            this.Latitude = latitude;
            this.Location = location;
            this.Longitude = longitude;
            this.Speed = speed;
            this.Updated = updated;
            this.Veh_reg = veh_reg;
            this.ReceivedDateTime = receivedDateTime;
            this.Resv1 = resv1;
            this.Resv2 = resv2;
            this.Resv3 = resv3;
        }
    }
}
