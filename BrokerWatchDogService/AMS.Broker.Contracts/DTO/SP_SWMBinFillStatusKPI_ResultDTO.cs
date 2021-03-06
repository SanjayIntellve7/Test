﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2019/06/07 - 12:42:50
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
    public partial class SP_SWMBinFillStatusKPI_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String BinID { get; set; }

        [DataMember()]
        public String RFID { get; set; }

        [DataMember()]
        public String BinType { get; set; }

        [DataMember()]
        public String BinColor { get; set; }

        [DataMember()]
        public Nullable<Double> Capacity { get; set; }

        [DataMember()]
        public String BinAddress { get; set; }

        [DataMember()]
        public Nullable<DateTime> TxDateTime { get; set; }

        [DataMember()]
        public Int32 FilledLevelStatus { get; set; }

        [DataMember()]
        public Nullable<Int32> FilledLevel { get; set; }

        [DataMember()]
        public Nullable<Int32> Thresholdlimit { get; set; }

        [DataMember()]
        public String FilledLevelStatusLabel { get; set; }

        [DataMember()]
        public String FilledLevelStatusColour { get; set; }

        [DataMember()]
        public String FilledLevelStatusImage { get; set; }

        public SP_SWMBinFillStatusKPI_ResultDTO()
        {
        }

        public SP_SWMBinFillStatusKPI_ResultDTO(Int32 iD, String binID, String rFID, String binType, String binColor, Nullable<Double> capacity, String binAddress, Nullable<DateTime> txDateTime, Int32 filledLevelStatus, Nullable<Int32> filledLevel, Nullable<Int32> thresholdlimit, String filledLevelStatusLabel, String filledLevelStatusColour, String filledLevelStatusImage)
        {
            this.ID = iD;
            this.BinID = binID;
            this.RFID = rFID;
            this.BinType = binType;
            this.BinColor = binColor;
            this.Capacity = capacity;
            this.BinAddress = binAddress;
            this.TxDateTime = txDateTime;
            this.FilledLevelStatus = filledLevelStatus;
            this.FilledLevel = filledLevel;
            this.Thresholdlimit = thresholdlimit;
            this.FilledLevelStatusLabel = filledLevelStatusLabel;
			this.FilledLevelStatusColour = filledLevelStatusColour;
            this.FilledLevelStatusImage = filledLevelStatusImage;
        }
    }
}
