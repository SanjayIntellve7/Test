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
    
    public partial class tblPrimarySecondaryServerMapping
    {
        public int ID { get; set; }
        public Nullable<int> InterfaceID { get; set; }
        public string PrimaryServerIP { get; set; }
        public Nullable<int> PrimaryServerPort { get; set; }
        public string PrimaryServerUserName { get; set; }
        public string PrimaryServerPassword { get; set; }
        public string PrimaryServerURL { get; set; }
        public string SecondaryServerIP { get; set; }
        public Nullable<int> SecondaryServerPort { get; set; }
        public string SecondaryServerUserName { get; set; }
        public string SecondaryServerPassword { get; set; }
        public string SecondaryServerURL { get; set; }
    }
}