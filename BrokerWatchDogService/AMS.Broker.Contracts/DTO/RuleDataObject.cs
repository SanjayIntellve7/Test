using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class RuleDataObject
    {
        [DataMember()]
        public int RuleId { get; set; }

        [DataMember()]
        public string RuleName { get; set; }

        [DataMember()]
        public  RuleData Rule { get; set; }

        [DataMember()]
        public Int32 RuleTypeID { get; set; }

        [DataMember()]
        public DateTime ScheduleStartTime { get; set; }

        [DataMember()]
        public DateTime ScheduleEndTime { get; set; }


        [DataMember()]
        public bool IsEnable { get; set; }

    }

    [DataContract()]
    public partial class RuleData
    {
        [DataMember()]
        public List<RuleExternalObject> RuleCondition { get; set; }
    }

    [DataContract()]
    public partial class RuleExternalObject
    {
        [DataMember()]
        public List<RuleInternalObject> InternalCondiion { get; set; }

        [DataMember()]
        public int ExternalConditionId { get; set; }

        [DataMember()]
        public int ExternalWaitTime { get; set; }

    }

    [DataContract()]
    public partial class RuleInternalObject
    {

        [DataMember()]
        public List<int> Sites { get; set; }

        [DataMember()]
        public List<int> Interfaces { get; set; }

        [DataMember()]
        public List<int> Devices { get; set; }

        [DataMember()]
        public List<int> EventCodes { get; set; }

        [DataMember()]
        public int InternalConditionId { get; set; }

        [DataMember()]
        public int InternalWaitTime { get; set; }

    }
}
