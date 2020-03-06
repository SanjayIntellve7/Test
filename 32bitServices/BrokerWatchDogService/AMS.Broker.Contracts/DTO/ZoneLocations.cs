using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class ZoneLocations
    {
        [DataMember, Required, Key]
        public Int64 ZoneId { get; set; }
        [DataMember, Required, Key]
        public Int64 LocationId { get; set; }
        [DataMember]
        public Decimal Lat { get; set; }
        [DataMember]
        public Decimal Long { get; set; }
    }
}
