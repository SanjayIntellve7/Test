﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2018/01/08 - 11:09:04
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
    public partial class tblHpcoeParkingDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Lot_id { get; set; }

        [DataMember()]
        public String Sensor_id { get; set; }

        [DataMember()]
        public String Spot_name { get; set; }

        [DataMember()]
        public String Spot_online { get; set; }

        [DataMember()]
        public Nullable<Boolean> Free { get; set; }

        [DataMember()]
        public String Lastintime { get; set; }

        [DataMember()]
        public String Lastouttime { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Lng { get; set; }

        public tblHpcoeParkingDTO()
        {
        }

        public tblHpcoeParkingDTO(Int32 iD, String lot_id, String sensor_id, String spot_name, String spot_online, Nullable<Boolean> free, String lastintime, String lastouttime, String lat, String lng)
        {
            this.ID = iD;
            this.Lot_id = lot_id;
            this.Sensor_id = sensor_id;
            this.Spot_name = spot_name;
            this.Spot_online = spot_online;
            this.Free = free;
            this.Lastintime = lastintime;
            this.Lastouttime = lastouttime;
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}
