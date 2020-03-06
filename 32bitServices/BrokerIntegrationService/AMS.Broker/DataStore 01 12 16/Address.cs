//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.IntegrationService.DataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Address()
        {
            this.Site = new HashSet<Site>();
            this.AccountBilling = new HashSet<AccountBilling>();
        }
    
        public int AddressId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public Nullable<int> SiteId { get; set; }
        public int DeletionStateCode { get; set; }
        public Nullable<int> AddressNumber { get; set; }
        public Nullable<int> AddressTypeCode { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostOfficeBox { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> UTCOffset { get; set; }
        public string UPSZone { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string Telephone1 { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<int> ShippingMethodCode { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public byte[] VersionNumber { get; set; }
        public string Fax { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<AccountBilling> AccountBilling { get; set; }
    }
}
