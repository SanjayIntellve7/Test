//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/03/26 - 14:18:01
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract(), KnownType(typeof(AccountDto)), Serializable]
    public partial class AccountInvoiceDto
    {
        [DataMember()]
        public Int32 InvoiceId { get; set; }

        [DataMember()]
        public Nullable<Int32> PriorityCode { get; set; }

        [DataMember()]
        public Int32 DeletionStateCode { get; set; }

        [DataMember()]
        public Nullable<Int32> AccountId { get; set; }

        [DataMember()]
        public Nullable<Int32> ContactId { get; set; }

        [DataMember()]
        public String InvoiceNumber { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<Decimal> DiscountAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> FreightAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalLineItemAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalLineItemDiscountAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalAmountLessFreight { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalDiscountAmount { get; set; }

        [DataMember()]
        public Nullable<Decimal> TotalTax { get; set; }

        [DataMember()]
        public Nullable<Int32> CreatedBy { get; set; }

        [DataMember()]
        public Nullable<DateTime> CreatedOn { get; set; }

        [DataMember()]
        public Nullable<Int32> ModifiedBy { get; set; }

        [DataMember()]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [DataMember()]
        public Int32 StateCode { get; set; }

        [DataMember()]
        public String BillTo_Name { get; set; }

        [DataMember()]
        public String BillTo_Line1 { get; set; }

        [DataMember()]
        public String BillTo_Line2 { get; set; }

        [DataMember()]
        public String BillTo_Line3 { get; set; }

        [DataMember()]
        public String BillTo_City { get; set; }

        [DataMember()]
        public String BillTo_StateOrProvince { get; set; }

        [DataMember()]
        public String BillTo_Country { get; set; }

        [DataMember()]
        public String BillTo_PostalCode { get; set; }

        [DataMember()]
        public String BillTo_Telephone { get; set; }

        [DataMember()]
        public String BillTo_Fax { get; set; }

        [DataMember()]
        public Nullable<Decimal> DiscountPercentage { get; set; }

        [DataMember()]
        public Nullable<DateTime> DueDate { get; set; }

        [DataMember()]
        public Nullable<Int32> TimeZoneId { get; set; }

        [DataMember()]
        public AccountDto Account { get; set; }

        public AccountInvoiceDto()
        {
        }
    }
}
