using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMBinAlertStatusKPI_ResultDTO
    {
        [DataMember()]
        public Int64 AlertId { get; set; }

        [DataMember()]
        public String MessageTypeId { get; set; }

        [DataMember()]
        public DateTime Sent { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertAckDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> AlertCloseDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> FilledLevel { get; set; }

        [DataMember()]
        public Nullable<Int32> BinMasterID { get; set; }

        public SP_SWMBinAlertStatusKPI_ResultDTO()
        {
        }

        public SP_SWMBinAlertStatusKPI_ResultDTO(Int64 alertId, String messageTypeId, DateTime sent, Nullable<DateTime> alertAckDateTime, Nullable<DateTime> alertCloseDateTime, Nullable<Int32> filledLevel, Nullable<Int32> binMasterID)
        {
            this.AlertId = alertId;
            this.MessageTypeId = messageTypeId;
            this.Sent = sent;
            this.AlertAckDateTime = alertAckDateTime;
            this.AlertCloseDateTime = alertCloseDateTime;
            this.FilledLevel = filledLevel;
            this.BinMasterID = binMasterID;
        }
    }
}
