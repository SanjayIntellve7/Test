using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblEscalationLevelMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String LevelID { get; set; }

        [DataMember()]
        public String LevelDescription { get; set; }

        [DataMember()]
        public String Escalationdetails { get; set; }

        public tblEscalationLevelMasterDTO()
        {
        }

        public tblEscalationLevelMasterDTO(Int32 iD, String levelID, String levelDescription, String escalationdetails)
        {
            this.ID = iD;
            this.LevelID = levelID;
            this.LevelDescription = levelDescription;
            this.Escalationdetails = escalationdetails;
        }
    }
}
