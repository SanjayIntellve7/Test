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
    
    public partial class tblANPRTransDetails
    {
        public int U_Id { get; set; }
        public string AppKey { get; set; }
        public string CamName { get; set; }
        public Nullable<int> No { get; set; }
        public byte[] LPImage { get; set; }
        public string RecNum { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string Direction { get; set; }
        public string RegName { get; set; }
        public byte[] DriverImage { get; set; }
        public string ContactNum { get; set; }
        public string AccessStatus { get; set; }
        public string Validated { get; set; }
        public byte[] ExtractedLPImage { get; set; }
        public string DriverImagePath { get; set; }
        public string NPImagePath { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMake { get; set; }
        public string Confidence { get; set; }
        public Nullable<int> AlertID { get; set; }
    }
}