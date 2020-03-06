using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AccountAlarmPanelDto
    {
        [DataMember]
        public int AccountAlarmPanelId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int EventGroupId { get; set; }
    }
}
