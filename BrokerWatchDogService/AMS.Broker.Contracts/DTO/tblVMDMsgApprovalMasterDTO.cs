using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVMDMsgApprovalMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String DisplayMsg { get; set; }

        [DataMember()]
        public String ApprovalStatus { get; set; }

        [DataMember()]
        public Guid ApprovedBy { get; set; }

        [DataMember()]
        public String ApprovedDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> VMDDeviceId { get; set; }

        public tblVMDMsgApprovalMasterDTO()
        {
        }

        public tblVMDMsgApprovalMasterDTO(Int32 iD, String displayMsg, String approvalStatus, Guid approvedBy, String approvedDateTime, Nullable<Int32> vMDDeviceId)
        {
            this.ID = iD;
            this.DisplayMsg = displayMsg;
            this.ApprovalStatus = approvalStatus;
            this.ApprovedBy = approvedBy;
            this.ApprovedDateTime = approvedDateTime;
            this.VMDDeviceId = vMDDeviceId;
        }
    }
}
