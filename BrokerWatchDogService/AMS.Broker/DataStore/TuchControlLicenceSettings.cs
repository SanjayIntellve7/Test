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
    
    public partial class TuchControlLicenceSettings
    {
        public TuchControlLicenceSettings()
        {
            this.GeneralSetting = new HashSet<GeneralSetting>();
        }
    
        public int LicenceSettingsId { get; set; }
    
        public virtual ICollection<GeneralSetting> GeneralSetting { get; set; }
    }
}
