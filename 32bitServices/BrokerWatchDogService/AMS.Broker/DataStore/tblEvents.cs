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
    
    public partial class tblEvents
    {
        public int ID { get; set; }
        public Nullable<int> TransactionID { get; set; }
        public string RawData { get; set; }
        public Nullable<int> Branch_ID { get; set; }
        public string Client_no { get; set; }
        public Nullable<int> Type_No { get; set; }
        public Nullable<int> Zone { get; set; }
        public Nullable<System.DateTime> EventDateTime { get; set; }
        public Nullable<System.DateTime> ReceivedDateTime { get; set; }
        public Nullable<long> AlertID { get; set; }
    }
}