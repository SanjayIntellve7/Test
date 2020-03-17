using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelSubsystemTypeMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String SubsystemType { get; set; }

        public tblIDSPanelSubsystemTypeMasterDTO()
        {
        }

        public tblIDSPanelSubsystemTypeMasterDTO(Int32 iD, String subsystemType)
        {
            this.ID = iD;
            this.SubsystemType = subsystemType;
        }
    }
}
