using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSOPTransactionDataDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 StepId { get; set; }

        [DataMember()]
        public Int32 SOPId { get; set; }

        [DataMember()]
        public Int32 ActionId { get; set; }

        [DataMember()]
        public Boolean IsExecuted { get; set; }

        [DataMember()]
        public DateTime? ExecutionDateTime { get; set; }

        [DataMember()]
        public Guid? ExecutedBy { get; set; }

        [DataMember()]
        public int? AlertID { get; set; }

         [DataMember()]
        public Boolean IsStopped { get; set; }

         [DataMember()]
         public string AlertOwner { get; set; }

         [DataMember()]
         public string StopComment { get; set; }
        


        public tblSOPTransactionDataDTO()
        {
        }

        public tblSOPTransactionDataDTO(Int32 iD, Int32 stepId, Int32 sOPId, Int32 actionId, Boolean isExecuted, DateTime executionDateTime, Guid executedBy, int alertID, Boolean isStopped, string alertOwner, string stopComment)
        {
            this.ID = iD;
            this.StepId = stepId;
            this.SOPId = sOPId;
            this.ActionId = actionId;
            this.IsExecuted = isExecuted;
            this.ExecutionDateTime = executionDateTime;
            this.ExecutedBy = executedBy;
            this.AlertID = alertID;
            this.IsStopped = isStopped;
            this.AlertOwner = alertOwner;
            this.StopComment = stopComment;
        }
    }
}
