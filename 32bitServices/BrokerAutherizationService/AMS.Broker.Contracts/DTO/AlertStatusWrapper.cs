using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class AlertStatusWrapper
    {
        [DataMember]
        public string Status;

        [DataMember]
        public Alert AlertObject;
    }
}
