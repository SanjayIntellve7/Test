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
    
    public partial class TimeZone
    {
        public TimeZone()
        {
            this.GeneralSetting = new HashSet<GeneralSetting>();
        }
    
        public int TimeZoneId { get; set; }
        public string Abbreviation { get; set; }
        public string Fullname { get; set; }
        public string Location { get; set; }
        public string Shift { get; set; }
    
        public virtual ICollection<GeneralSetting> GeneralSetting { get; set; }
    }
}
