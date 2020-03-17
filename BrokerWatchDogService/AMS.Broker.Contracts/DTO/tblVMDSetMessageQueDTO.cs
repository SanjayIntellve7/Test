using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVMDSetMessageQueDTO
    {
        //[DataMember()]
        //public Int32 ID { get; set; }

        //[DataMember()]
        //public Nullable<Int32> DeviceID { get; set; }

        //[DataMember()]
        //public Nullable<Int32> VMDEquipmentID { get; set; }

        //[DataMember()]
        //public String VMDMessage { get; set; }

        //[DataMember()]
        //public Nullable<Guid> UserID { get; set; }

        //[DataMember()]
        //public Nullable<DateTime> MessageSetDateTime { get; set; }

        //[DataMember()]
        //public Nullable<Int32> MessageSetStatus { get; set; }

        //[DataMember()]
        //public Nullable<Int32> MessageSetType { get; set; }

        //[DataMember()]
        //public String MessageStatusRemarks { get; set; }

        //public tblVMDSetMessageQueDTO()
        //{
        //}

        //public tblVMDSetMessageQueDTO(Int32 iD, Nullable<Int32> deviceID, Nullable<Int32> vMDEquipmentID, String vMDMessage, Nullable<Guid> userID, Nullable<DateTime> messageSetDateTime, Nullable<Int32> messageSetStatus, Nullable<Int32> messageSetType, String messageStatusRemarks)
        //{
        //    this.ID = iD;
        //    this.DeviceID = deviceID;
        //    this.VMDEquipmentID = vMDEquipmentID;
        //    this.VMDMessage = vMDMessage;
        //    this.UserID = userID;
        //    this.MessageSetDateTime = messageSetDateTime;
        //    this.MessageSetStatus = messageSetStatus;
        //    this.MessageSetType = messageSetType;
        //    this.MessageStatusRemarks = messageStatusRemarks;
        //}

        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public String VMDEquipmentID { get; set; }

        [DataMember()]
        public String VMDMessage { get; set; }

        [DataMember()]
        public Nullable<Guid> UserID { get; set; }

        [DataMember()]
        public Nullable<DateTime> MessageSetDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> MessageSetStatus { get; set; }

        [DataMember()]
        public Nullable<Int32> MessageSetType { get; set; }

        [DataMember()]
        public String MessageStatusRemarks { get; set; }

        [DataMember()]
        public String MessageType { get; set; }

        [DataMember()]
        public String MessageID { get; set; }

        public tblVMDSetMessageQueDTO()
        {
        }

        public tblVMDSetMessageQueDTO(Int32 iD, Nullable<Int32> deviceID, String vMDEquipmentID, String vMDMessage, Nullable<Guid> userID, Nullable<DateTime> messageSetDateTime, Nullable<Int32> messageSetStatus, Nullable<Int32> messageSetType, String messageStatusRemarks, String messageType, String messageID)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.VMDEquipmentID = vMDEquipmentID;
            this.VMDMessage = vMDMessage;
            this.UserID = userID;
            this.MessageSetDateTime = messageSetDateTime;
            this.MessageSetStatus = messageSetStatus;
            this.MessageSetType = messageSetType;
            this.MessageStatusRemarks = messageStatusRemarks;
            this.MessageType = messageType;
            this.MessageID = messageID;
        }
    }
}