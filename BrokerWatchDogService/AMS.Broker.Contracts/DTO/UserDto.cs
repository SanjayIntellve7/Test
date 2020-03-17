using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class UserDto
    {
        [DataMember, Required, Key]
        public int UserId { get; set; }

        [DataMember]
        public string UserSid { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int? UserTypeId { get; set; }

        [DataMember]
        public int PersonId { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public PersonDto Person { get; set; }

        [DataMember]
        public UserTypeDto UserType { get; set; }

        [DataMember]
        public Nullable<Guid> MembershipUserId { get; set; }

        //ToDO: add later
        [DataMember]
        public bool IsLocked { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }

        [DataMember]
        public string PasswordValidity { get; set; } //amit 25092017

        [DataMember]
        public string DomainName { get; set; } //komal 24052019

        [DataMember]
        public Nullable<bool> IsDomainUser { get; set; } //komal 24052019


        public override string ToString()
        {
            return Username;
        }
    }
}
