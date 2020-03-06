//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/19 - 18:54:44
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
    [DataContract()]
    public partial class SP_GetAccountsCollection_ResultDTO
    {
        [DataMember()]
        public Int32 AccountId { get; set; }

        [DataMember()]
        public String AccountNumber { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryContactId { get; set; }

        [DataMember()]
        public String FullName { get; set; }

        [DataMember()]
        public Int32 PersonId { get; set; }

        [DataMember()]
        public Byte[] Portrait { get; set; }

        public SP_GetAccountsCollection_ResultDTO()
        {
        }

        public SP_GetAccountsCollection_ResultDTO(Int32 accountId, String accountNumber, String name, Nullable<Int32> primaryContactId, String fullName, Int32 personId, Byte[] portrait)
        {
			this.AccountId = accountId;
			this.AccountNumber = accountNumber;
			this.Name = name;
			this.PrimaryContactId = primaryContactId;
			this.FullName = fullName;
			this.PersonId = personId;
			this.Portrait = portrait;
        }
    }
}
