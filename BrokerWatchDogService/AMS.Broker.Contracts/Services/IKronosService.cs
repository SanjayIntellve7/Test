using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IKronosService
    {
        [OperationContract]
        int ConsumeEvent(string message);

        [OperationContract]
        EventTypeTemplateDto GetEventTypeTemplate(string protocolId);
    }
}
