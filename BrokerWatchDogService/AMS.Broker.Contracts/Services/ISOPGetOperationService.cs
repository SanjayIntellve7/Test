using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISOPGetOperationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        List<tblSOPActionMasterDTO> GetSOPActionMasterDetails(string authToken);

        [OperationContract]
        List<tblSOPActionDataMasterDTO> GetSOPActionDataMasterDetails(string authToken);

        [OperationContract]
        List<tblStandardSOPMasterDTO> GetSOPMasterDetails(string authToken);

        [OperationContract]
        List<tblSOPStepDataDTO> GetSOPStepDetails(string authToken);

        [OperationContract]
        List<tblSOPStepDataDTO> GetSOPStepDetailsById(string authToken, int SopId);

        [OperationContract]
        List<tblSOPTransactionDataDTO> GetSOPTransactionDetails(string authToken);


        [OperationContract]
        List<tblcustomeremergencycontactDTO> GetEmergenctContactCollection(string authToken);

        [OperationContract]
        List<tblSOPIconMasterDTO> GetSOPIconList(string authToken);

        [OperationContract]
        List<EventGroupDto> GetUsedEventGroupList(string authToken, int SopId);

        [OperationContract]
        List<EventCodeDto> GetUsedEventCodeList(string authToken, int SopId);

        [OperationContract]
        List<tblSOPTransactionDataDTO> GetAlertSOPDetails(string authToken, int AlertsID);

        [OperationContract]
        tblStandardSOPMasterDTO GetSOPMasterDetailsbyId(string authToken, int SOPId); // jatin 08072019

    }
}
