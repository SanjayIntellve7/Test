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
    
    public partial class Account
    {
        public Account()
        {
            this.Account1 = new HashSet<Account>();
            this.AccountInvoice = new HashSet<AccountInvoice>();
            this.Address = new HashSet<Address>();
            this.Interface = new HashSet<Interface>();
            this.Site = new HashSet<Site>();
            this.AlertType = new HashSet<AlertType>();
            this.Person = new HashSet<Person>();
            this.AccountAlarmPanel = new HashSet<AccountAlarmPanel>();
            this.AccountAnalyticsAlgorithmType = new HashSet<AccountAnalyticsAlgorithmType>();
            this.AccountNvrAlertType = new HashSet<AccountNvrAlertType>();
        }
    
        public int AccountId { get; set; }
        public Nullable<int> AccountTypeId { get; set; }
        public Nullable<int> ParentAccountId { get; set; }
        public int DeletionStateCode { get; set; }
        public Nullable<int> ServicePackageId { get; set; }
        public Nullable<int> PrimaryContactId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public string WebSiteURL { get; set; }
        public Nullable<int> TimeZoneId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public Nullable<int> AccountBillingId { get; set; }
        public byte[] AccountLogo { get; set; }
        public bool BillingSameAsAccountAddress { get; set; }
    
        public virtual ICollection<Account> Account1 { get; set; }
        public virtual Account Account2 { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ServicePackage ServicePackage { get; set; }
        public virtual ICollection<AccountInvoice> AccountInvoice { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Interface> Interface { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<AlertType> AlertType { get; set; }
        public virtual AccountBilling AccountBilling { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<AccountAlarmPanel> AccountAlarmPanel { get; set; }
        public virtual ICollection<AccountAnalyticsAlgorithmType> AccountAnalyticsAlgorithmType { get; set; }
        public virtual ICollection<AccountNvrAlertType> AccountNvrAlertType { get; set; }
    }
}
