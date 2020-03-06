using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
 
    [DataContract, Serializable]
    public sealed class UserLocation
    {
        [DataMember, Required, Key]
        public int LocationId { get; set; }
        [DataMember, Required, Key]
        public string Username { get; set; }
        [DataMember]
        public Decimal Alt { get; set; }
        [DataMember]
        public Decimal Lat { get; set; }
        [DataMember]
        public Decimal Long { get; set; }
        [DataMember]
        public bool IsFavorite { get; set; }
        [DataMember]
        public Nullable<double> Zoomlevel { get; set; }
        [DataMember]
        public string Favaddress { get; set; }
    }
}
