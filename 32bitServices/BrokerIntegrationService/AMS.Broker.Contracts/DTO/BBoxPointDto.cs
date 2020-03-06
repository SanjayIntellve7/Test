using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(SiteDto)), KnownType(typeof(BBoxPointDto))]
    public class BBoxPointDto
    {
        [DataMember, Required, Key]
        public Int32 BBoxPointId { get; set; }

        [DataMember]
        public Int32 SiteId { get; set; }

        [DataMember]
        public double Lat { get; set; }

        [DataMember]
        public double Long { get; set; }

        [DataMember]
        public double Alt { get; set; }

        [DataMember]
        public SiteDto Site { get; set; }
    }
}
