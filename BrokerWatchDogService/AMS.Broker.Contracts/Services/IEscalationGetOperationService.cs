using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IEscalationGetOperationService
    {
        [OperationContract]
        List<tblEscalationConfigMasterDTO> GetAllEscalationConfigMaster(string authtoken);

        [OperationContract]
        tblEscalationConfigMasterDTO GetEscalationConfigMasterDetailsByID(int id);

        [OperationContract]
        List<InterfaceDto> GetAllInterfaces(string authToken);

        [OperationContract]
        List<EventCodeDto> GetUsedEventCodeList(string authToken, int EscalationId);
    }
}
