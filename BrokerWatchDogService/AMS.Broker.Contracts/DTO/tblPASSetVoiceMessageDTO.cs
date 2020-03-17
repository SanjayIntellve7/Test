using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPASSetVoiceMessageDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public String PASVoiceMessage { get; set; }

        [DataMember()]
        public Nullable<Guid> UserID { get; set; }

        [DataMember()]
        public Nullable<DateTime> VoiceMessageSetDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> VoiceMessageSetStatus { get; set; }

        [DataMember()]
        public Nullable<Int32> VoiceMessageSetType { get; set; }

        [DataMember()]
        public String MessageStatusRemarks { get; set; }


        [DataMember()]
        public Nullable<Int32> VoiceMessageID { get; set; }

        public tblPASSetVoiceMessageDTO()
        {
        }

        public tblPASSetVoiceMessageDTO(Int32 iD, Nullable<Int32> deviceID, String pASVoiceMessage, Nullable<Guid> userID, Nullable<DateTime> voiceMessageSetDateTime, Nullable<Int32> voiceMessageSetStatus, Nullable<Int32> voiceMessageSetType, String messageStatusRemarks, Nullable<Int32> voiceMessageID)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.PASVoiceMessage = pASVoiceMessage;
            this.UserID = userID;
            this.VoiceMessageSetDateTime = voiceMessageSetDateTime;
            this.VoiceMessageSetStatus = voiceMessageSetStatus;
            this.VoiceMessageSetType = voiceMessageSetType;
            this.MessageStatusRemarks = messageStatusRemarks;
            this.VoiceMessageID = voiceMessageID;
        }

    }
}
