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
    
    public partial class tbluserassigmentlog
    {
        public int ID { get; set; }
        public int AlertID { get; set; }
        public Nullable<System.Guid> ExistingMembershipID { get; set; }
        public Nullable<System.Guid> NewMembershipID { get; set; }
        public System.DateTime updatedatetime { get; set; }
        public Nullable<int> OperationsMasterID { get; set; }
        public Nullable<System.Guid> AuthToken { get; set; }
    }
}
