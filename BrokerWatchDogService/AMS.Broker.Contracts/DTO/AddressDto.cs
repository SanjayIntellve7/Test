//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/03/26 - 14:18:03
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
    [DataContract/*(IsReference = true)*/, KnownType(typeof(PersonDto)), Serializable]
    public partial class AddressDto
    {
        [DataMember()]
        public Int32 AddressId { get; set; }

        [DataMember()]
        public Nullable<Int32> AccountId { get; set; }

        [DataMember()]
        public Nullable<Int32> PersonId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        [DataMember()]
        public Int32 DeletionStateCode { get; set; }

        [DataMember()]
        public Nullable<Int32> AddressNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> AddressTypeCode { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Line1 { get; set; }

        [DataMember()]
        public String Line2 { get; set; }

        [DataMember()]
        public String Line3 { get; set; }

        [DataMember()]
        public String City { get; set; }

        [DataMember()]
        public String StateOrProvince { get; set; }

        [DataMember()]
        public String County { get; set; }

        [DataMember()]
        public String Country { get; set; }

        [DataMember()]
        public String PostOfficeBox { get; set; }

        [DataMember()]
        public String PostalCode { get; set; }

        [DataMember()]
        public Nullable<Int32> UTCOffset { get; set; }

        [DataMember()]
        public String UPSZone { get; set; }

        [DataMember()]
        public Nullable<Double> Latitude { get; set; }

        [DataMember()]
        public String Telephone1 { get; set; }

        [DataMember()]
        public Nullable<Double> Longitude { get; set; }

        [DataMember()]
        public Nullable<Int32> ShippingMethodCode { get; set; }

        [DataMember()]
        public String Telephone2 { get; set; }

        [DataMember()]
        public String Telephone3 { get; set; }

        [DataMember()]
        public Byte[] VersionNumber { get; set; }

        [DataMember()]
        public String Fax { get; set; }

        [DataMember()]
        public Nullable<Int32> CreatedBy { get; set; }

        [DataMember()]
        public Nullable<DateTime> CreatedOn { get; set; }

        [DataMember()]
        public Nullable<Int32> ModifiedBy { get; set; }

        [DataMember()]
        public Nullable<DateTime> ModifiedOn { get; set; }

        public AddressDto()
        {
        }
    }
}
