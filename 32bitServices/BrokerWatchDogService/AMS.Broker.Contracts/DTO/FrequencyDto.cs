//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/03/26 - 14:18:05
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
    public partial class FrequencyDto
    {
        [DataMember()]
        public Int32 FrequencyId { get; set; }

        [DataMember()]
        public String FrequencyName { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> Hour { get; set; }

        [DataMember()]
        public Nullable<Int32> DayOfWeek { get; set; }

        [DataMember()]
        public Nullable<Int32> Week { get; set; }

        [DataMember()]
        public Nullable<Int32> DayOfMonth { get; set; }

        [DataMember()]
        public List<DeliveryMethodDto> DeliveryMethod { get; set; }

        public FrequencyDto()
        {
        }
    }
}