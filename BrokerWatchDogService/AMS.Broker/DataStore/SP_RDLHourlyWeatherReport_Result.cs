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
    
    public partial class SP_RDLHourlyWeatherReport_Result
    {
        public Nullable<double> Temp { get; set; }
        public Nullable<double> Dewpoint { get; set; }
        public string Sky { get; set; }
        public Nullable<double> WindSpeed { get; set; }
        public Nullable<int> UV { get; set; }
        public Nullable<double> HeatIndex { get; set; }
        public Nullable<double> MSLP { get; set; }
        public Nullable<int> Hours { get; set; }
        public Nullable<System.DateTime> ForecastDatetime { get; set; }
    }
}
