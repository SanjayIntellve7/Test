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
    
    public partial class GeneralSetting
    {
        public string SystemName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public byte[] Logo { get; set; }
        public int DefaultLanguage { get; set; }
        public int DefaultTimeZoneId { get; set; }
        public Nullable<int> LicenceSettingsId { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual TimeZone TimeZone { get; set; }
        public virtual TuchControlLicenceSettings TuchControlLicenceSettings { get; set; }
    }
}
