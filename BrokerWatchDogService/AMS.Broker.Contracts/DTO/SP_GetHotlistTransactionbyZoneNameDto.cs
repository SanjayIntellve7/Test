using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetHotlistTransactionbyZoneNameDto
    {
        [DataMember()]
        public Nullable<Int32> VoilationCount { get; set; }

        [DataMember()]
        public String Entity { get; set; }

        public SP_GetHotlistTransactionbyZoneNameDto()
        {
        }

        public SP_GetHotlistTransactionbyZoneNameDto(Nullable<Int32> voilationCount, String entity)
        {
            this.VoilationCount = voilationCount;
            this.Entity = entity;
        }
    }
}
