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
    
    public partial class Login
    {
        public System.Guid AuthToken { get; set; }
        public string SecurityUserId { get; set; }
        public string Identifier { get; set; }
        public System.DateTime LoginDate { get; set; }
        public Nullable<System.DateTime> LogoutDate { get; set; }
        public string IdentifierIP { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
    }
}
