﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/05/26 - 12:30:02
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
    public partial class tblWeatherthresholdDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> CityID { get; set; }

        [DataMember()]
        public String CityName { get; set; }

        [DataMember()]
        public Nullable<Double> Tempthreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Mintempthreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Maxtempthreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Humiditythreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Pressurethreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Windspeedthreshold { get; set; }

        [DataMember()]
        public String WindNamethreshold { get; set; }

        [DataMember()]
        public String Winddirthreshold { get; set; }

        [DataMember()]
        public String Winddirnamethreshold { get; set; }

        [DataMember()]
        public Nullable<Double> Cloudsthreshold { get; set; }

        [DataMember()]
        public String CloudNamethreshold { get; set; }

        [DataMember()]
        public String WeatherName { get; set; }

        public tblWeatherthresholdDTO()
        {
        }

        public tblWeatherthresholdDTO(Int32 iD, Nullable<Int32> cityID, String cityName, Nullable<Double> tempthreshold, Nullable<Double> mintempthreshold, Nullable<Double> maxtempthreshold, Nullable<Double> humiditythreshold, Nullable<Double> pressurethreshold, Nullable<Double> windspeedthreshold, String windNamethreshold, String winddirthreshold, String winddirnamethreshold, Nullable<Double> cloudsthreshold, String cloudNamethreshold, String weatherName)
        {
            this.ID = iD;
            this.CityID = cityID;
            this.CityName = cityName;
            this.Tempthreshold = tempthreshold;
            this.Mintempthreshold = mintempthreshold;
            this.Maxtempthreshold = maxtempthreshold;
            this.Humiditythreshold = humiditythreshold;
            this.Pressurethreshold = pressurethreshold;
            this.Windspeedthreshold = windspeedthreshold;
            this.WindNamethreshold = windNamethreshold;
            this.Winddirthreshold = winddirthreshold;
            this.Winddirnamethreshold = winddirnamethreshold;
            this.Cloudsthreshold = cloudsthreshold;
            this.CloudNamethreshold = cloudNamethreshold;
            this.WeatherName = weatherName;
        }
    }
}
