using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPASPreDefinedVoiceMessageDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String PredefinedVoicemessage { get; set; }

          [DataMember()]
        public Nullable<int> FileID { get; set; }

        public tblPASPreDefinedVoiceMessageDTO()
        {
        }

        public tblPASPreDefinedVoiceMessageDTO(Int32 iD, String predefinedVoicemessage, int fileID)
        {
            this.ID = iD;
            this.PredefinedVoicemessage = predefinedVoicemessage;
            this.FileID = fileID;
        }
    }
}
