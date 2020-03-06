using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(SiteTypeDto))]
    public sealed class SiteTypeDto
    {        
        [DataMember, Required, Key]
        public Int32 SiteTypeId { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public byte[] Icon { get; set; }

        [DataMember]
        public int HierarchyLevel { get; set; }
    }
}
