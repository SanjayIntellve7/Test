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
    
    public partial class tblDeviceGeoTrackHistory
    {
        public long DevMovHisID { get; set; }
        public long DevId { get; set; }
        public string AssetName { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string SPEED { get; set; }
        public string HEADING { get; set; }
        public Nullable<System.DateTime> POSDATETIME { get; set; }
        public Nullable<int> IGNSTATUS { get; set; }
        public string LOCATION { get; set; }
        public Nullable<System.DateTime> LocDateTime { get; set; }
    }
}
