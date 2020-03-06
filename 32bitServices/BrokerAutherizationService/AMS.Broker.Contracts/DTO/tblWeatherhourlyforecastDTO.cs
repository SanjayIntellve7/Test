﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/05/30 - 12:04:23
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
    public partial class tblWeatherhourlyforecastDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> CityID { get; set; }

        [DataMember()]
        public String CityName { get; set; }

        [DataMember()]
        public Nullable<DateTime> ForecastDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> ForecastDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> Epoc { get; set; }

        [DataMember()]
        public String Pretty { get; set; }

        [DataMember()]
        public Nullable<Double> Temp { get; set; }

        [DataMember()]
        public Nullable<Double> Dewpoint { get; set; }

        [DataMember()]
        public String Condition { get; set; }

        [DataMember()]
        public String Icon { get; set; }

        [DataMember()]
        public String Icon_URL { get; set; }

        [DataMember()]
        public Nullable<Int32> Fctcode { get; set; }

        [DataMember()]
        public String Sky { get; set; }

        [DataMember()]
        public Nullable<Double> WindSpeed { get; set; }

        [DataMember()]
        public Nullable<Double> WindDirection { get; set; }

        [DataMember()]
        public String WindName { get; set; }

        [DataMember()]
        public Nullable<Int32> UV { get; set; }

        [DataMember()]
        public Nullable<Double> HeatIndex { get; set; }

        [DataMember()]
        public Nullable<Double> Feelslike { get; set; }

        [DataMember()]
        public Nullable<Double> QPF { get; set; }

        [DataMember()]
        public Nullable<Double> Snow { get; set; }

        [DataMember()]
        public Nullable<Int32> POP { get; set; }

        [DataMember()]
        public Nullable<Double> MSLP { get; set; }

        [DataMember()]
        public Int32 AlertID { get; set; }

        public tblWeatherhourlyforecastDTO()
        {
        }

        public tblWeatherhourlyforecastDTO(Int32 iD, Nullable<Int32> cityID, String cityName, Nullable<DateTime> forecastDate, Nullable<DateTime> forecastDateTime, Nullable<Int32> epoc, String pretty, Nullable<Double> temp, Nullable<Double> dewpoint, String condition, String icon, String icon_URL, Nullable<Int32> fctcode, String sky, Nullable<Double> windSpeed, Nullable<Double> windDirection, String windName, Nullable<Int32> uV, Nullable<Double> heatIndex, Nullable<Double> feelslike, Nullable<Double> qPF, Nullable<Double> snow, Nullable<Int32> pOP, Nullable<Double> mSLP, Int32 alertID)
        {
            this.ID = iD;
            this.CityID = cityID;
            this.CityName = cityName;
            this.ForecastDate = forecastDate;
            this.ForecastDateTime = forecastDateTime;
            this.Epoc = epoc;
            this.Pretty = pretty;
            this.Temp = temp;
            this.Dewpoint = dewpoint;
            this.Condition = condition;
            this.Icon = icon;
            this.Icon_URL = icon_URL;
            this.Fctcode = fctcode;
            this.Sky = sky;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.WindName = windName;
            this.UV = uV;
            this.HeatIndex = heatIndex;
            this.Feelslike = feelslike;
            this.QPF = qPF;
            this.Snow = snow;
            this.POP = pOP;
            this.MSLP = mSLP;
            this.AlertID = alertID;
        }
    }
}
