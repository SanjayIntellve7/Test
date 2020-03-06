using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblAlertContextDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String AlertContextName { get; set; }

        [DataMember()]
        public String AlertContextDescription { get; set; }

        [DataMember()]
        public Nullable<Int32> Action { get; set; }

        [DataMember()]
        public String Severity { get; set; }

        [DataMember()]
        public String EmailID { get; set; }

        public tblAlertContextDTO()
        {
        }

        public tblAlertContextDTO(Int32 iD, String alertContextName, String alertContextDescription, Nullable<Int32> action, String severity, String emailID)
        {
            this.ID = iD;
            this.AlertContextName = alertContextName;
            this.AlertContextDescription = alertContextDescription;
            this.Action = action;
            this.Severity = severity;
            this.EmailID = emailID;
        }
    }
}
