using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface INvrAlarmConsumerService
    {
        [OperationContract]
        void ConsumeAlarm(IEnumerable<VideoAlarmEvent> videoAlarmEvents);
    }
}
