//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblWeatherhourlyforecast
    {
        public int ID { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public Nullable<System.DateTime> ForecastDate { get; set; }
        public Nullable<System.DateTime> ForecastDateTime { get; set; }
        public string Epoc { get; set; }
        public string Pretty { get; set; }
        public string Temp { get; set; }
        public string Dewpoint { get; set; }
        public string Condition { get; set; }
        public string Icon { get; set; }
        public string Icon_URL { get; set; }
        public string Fctcode { get; set; }
        public string Sky { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string WindName { get; set; }
        public string UV { get; set; }
        public string HeatIndex { get; set; }
        public string Feelslike { get; set; }
        public string QPF { get; set; }
        public string Snow { get; set; }
        public string POP { get; set; }
        public string MSLP { get; set; }
        public int AlertID { get; set; }
    }
}
