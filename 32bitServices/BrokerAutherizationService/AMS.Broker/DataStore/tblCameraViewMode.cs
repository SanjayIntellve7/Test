//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.AutherizationService.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCameraViewMode
    {
        public int ID { get; set; }
        public int CameraID { get; set; }
        public int FPS { get; set; }
        public string CameraResolution { get; set; }
        public Nullable<int> BandWidth { get; set; }
        public Nullable<int> InstanceRunning { get; set; }
        public Nullable<bool> ISEnabled { get; set; }
    }
}
