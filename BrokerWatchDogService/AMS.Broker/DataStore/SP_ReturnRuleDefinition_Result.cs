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
    
    public partial class SP_ReturnRuleDefinition_Result
    {
        public int ID { get; set; }
        public Nullable<int> AlertDevice { get; set; }
        public Nullable<int> DeviceID { get; set; }
        public string Severity { get; set; }
        public Nullable<int> EventyType { get; set; }
        public Nullable<int> TimeSec { get; set; }
        public Nullable<System.DateTime> FromTime { get; set; }
        public Nullable<System.DateTime> ToTime { get; set; }
    }
}
