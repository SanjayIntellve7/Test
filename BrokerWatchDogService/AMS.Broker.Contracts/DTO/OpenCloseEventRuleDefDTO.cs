using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class OpenCloseEventRuleDefDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> AlertDevice { get; set; }       

        [DataMember()]
        public String Severity { get; set; }

        [DataMember()]
        public String OpeningEventyType { get; set; }

        [DataMember()]
        public Nullable<Int32> OpeningBufferTime { get; set; }

        [DataMember()]
        public String ClosingEventyType { get; set; }

        [DataMember()]
        public Nullable<Int32> ClosingBufferTime { get; set; }     

        [DataMember()]
        public string OpenTimefrom { get; set; }

        [DataMember()]
        public string OpenTimeto { get; set; }

        [DataMember()]
        public string CloseTimefrom { get; set; }

        [DataMember()]
        public string CloseTimeto { get; set; }


        [DataMember()]
        public bool IsAlertflag { get; set; }

        public OpenCloseEventRuleDefDTO()
        {
        }

        public OpenCloseEventRuleDefDTO(Int32 iD, Nullable<Int32> alertDevice, String severity, String openingEventyType, Nullable<Int32> openingBufferTime, String closingEventyType, Nullable<Int32> closingBufferTime, string openTimefrom, string openTimeto, string closeTimefrom, string closeTimeto, bool isAlertflag)
        {
			this.ID = iD;
			this.AlertDevice = alertDevice;		
			this.Severity = severity;
            this.OpeningEventyType = openingEventyType;
            this.OpeningBufferTime = openingBufferTime;
            this.OpenTimefrom = openTimefrom;
            this.OpenTimeto = openTimeto;
            this.CloseTimefrom = closeTimefrom;
            this.CloseTimeto = closeTimeto;
            this.IsAlertflag = IsAlertflag;
            this.ClosingEventyType = closingEventyType;           
            this.ClosingBufferTime = closingBufferTime;
        }
    }
}
