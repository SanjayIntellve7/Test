using QL.Communication.Messaging;
using QL.Communication.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.Services
{
    public class AlarmsEventsRequestMessageExtended : AlarmsEventsRequestMessage
    {
        public override void Serialize(IPropertyBag propertyBag)
        {
            base.Serialize(propertyBag);
            propertyBag["request_type"] = "recent_and_active";
        }
    }

    public class AlarmsEventsResponseMessageExtended : AlarmsEventsResponseMessage
    {
        public override void Deserialize(IPropertyBag propertyBag)
        {
            base.Deserialize(propertyBag);
        }
    }
}