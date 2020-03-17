using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblStateMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String StateName { get; set; }

        public tblStateMasterDTO()
        {
        }

        public tblStateMasterDTO(Int32 iD, String stateName)
        {
            this.ID = iD;
            this.StateName = stateName;
        }
    }
}
