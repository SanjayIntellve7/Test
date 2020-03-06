using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    public sealed class ResourceData
    {
        public Guid AuthToken { get; set; }
        public byte[] Data { get; set; }
        public Guid ResourceId { get; set; }
        public Int32 EvidenceType { get; set; }
    }
}
