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
    
    public partial class tbluserdeviceinfo
    {
        public int ID { get; set; }
        public System.Guid UserID { get; set; }
        public int SiteID { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public int DeviceID { get; set; }
        public bool LiveView { get; set; }
        public bool PlaybackView { get; set; }
        public bool RecordingExport { get; set; }
        public bool PTZControl { get; set; }
        public bool NonCamView { get; set; }
        public bool NonCamControl { get; set; }
    }
}