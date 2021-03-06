//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/03/26 - 14:18:06
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
    [DataContract(), KnownType(typeof(ContactDto)), KnownType(typeof(PersonContactTypeDto)), Serializable]
    public partial class PersonDto
    {
        [DataMember()]
        public Int32 PersonId { get; set; }

        [DataMember()]
        public String Title { get; set; }

        [DataMember()]
        public String FirstName { get; set; }

        [DataMember()]
        public String NickName { get; set; }

        [DataMember()]
        public String MiddleName { get; set; }

        [DataMember()]
        public String LastName { get; set; }

        [DataMember()]
        public String Suffix { get; set; }

        [DataMember()]
        public String FullName { get; set; }

        [DataMember()]
        public Nullable<DateTime> BirthDate { get; set; }

        [DataMember()]
        public Nullable<Int32> AgeRange { get; set; }

        [DataMember()]
        public Nullable<Int32> Ethnicity { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<Int32> GenderCode { get; set; }

        [DataMember()]
        public Nullable<Int32> EducationCode { get; set; }

        [DataMember()]
        public String ExternalIdentifier { get; set; }

        [DataMember()]
        public Byte[] Portrait { get; set; }

        [DataMember()]
        public Nullable<int> AccountId { get; internal set; }

        [DataMember()]
        public Nullable<DateTime> CreatedOn { get; set; }

        [DataMember()]
        public Nullable<Int32> CreatedBy { get; set; }

        [DataMember()]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [DataMember()]
        public Nullable<Int32> ModifiedBy { get; set; }

        [DataMember()]
        public List<AddressDto> Address { get; set; }

        [DataMember()]
        public List<ContactDto> Contacts { get; set; }

        [DataMember()]
        public string JobTitle { get; set; }

        [DataMember()]
        public string Password { get; set; }

        [DataMember()]
        public string PrimaryAccountAdministratorPassword { get; set; }

        [DataMember()]
        public IList<PersonContactTypeDto> PreferedContactTypes { get; set; }

        [DataMember()]
        public ContactDto PrimaryContact { get; set; }

        public PersonDto()
        {
        }
    }
}
