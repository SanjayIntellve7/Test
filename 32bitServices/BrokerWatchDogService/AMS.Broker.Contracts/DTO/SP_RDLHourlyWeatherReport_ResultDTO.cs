﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/05/31 - 14:43:40
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
    public partial class SP_RDLHourlyWeatherReport_ResultDTO
    {
        [DataMember()]
        public Nullable<Double> Temp { get; set; }

        [DataMember()]
        public Nullable<Double> Dewpoint { get; set; }

        [DataMember()]
        public String Sky { get; set; }

        [DataMember()]
        public Nullable<Double> WindSpeed { get; set; }

        [DataMember()]
        public Nullable<Int32> UV { get; set; }

        [DataMember()]
        public Nullable<Double> HeatIndex { get; set; }

        [DataMember()]
        public Nullable<Double> MSLP { get; set; }

        [DataMember()]
        public Nullable<Int32> Hours { get; set; }

        [DataMember()]
        public Nullable<DateTime> ForecastDatetime { get; set; }

        public SP_RDLHourlyWeatherReport_ResultDTO()
        {
        }

        public SP_RDLHourlyWeatherReport_ResultDTO(Nullable<Double> temp, Nullable<Double> dewpoint, String sky, Nullable<Double> windSpeed, Nullable<Int32> uV, Nullable<Double> heatIndex, Nullable<Double> mSLP, Nullable<Int32> hours, Nullable<DateTime> forecastDatetime)
        {
            this.Temp = temp;
            this.Dewpoint = dewpoint;
            this.Sky = sky;
            this.WindSpeed = windSpeed;
            this.UV = uV;
            this.HeatIndex = heatIndex;
            this.MSLP = mSLP;
            this.Hours = hours;
            this.ForecastDatetime = forecastDatetime;
        }
    }
}
