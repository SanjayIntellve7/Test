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
    
    public partial class tblVehicleCounter
    {
        public decimal ID { get; set; }
        public Nullable<int> LaneID { get; set; }
        public Nullable<int> VehicleTypeID { get; set; }
        public Nullable<System.DateTime> TxnDateTime { get; set; }
        public Nullable<decimal> Count { get; set; }
        public Nullable<int> DeviceID { get; set; }
    }
}
