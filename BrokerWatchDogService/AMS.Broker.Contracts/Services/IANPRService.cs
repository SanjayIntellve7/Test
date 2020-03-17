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
    public interface IANPRService
    {
        [OperationContract]
        void ConsumeANPRAlert(string AnprId);

        [OperationContract]
        string ConsumeAnprAlert(tblANPRTransDetailsDto EventData);

        [OperationContract]
        IEnumerable<tblANPRTransDetailsDto> GetANPRAlertDetail(long AlertId, string authToken);
               
        [OperationContract]
        IEnumerable<SP_GetANPRStatusDetails_ResultDTO> GetANPRDetailForDay(string authToken, int flag);

        [OperationContract]
        IEnumerable<tblANPRVehicleRegistrationDetailDTO> GetANPRRegisteredVehicles(string authToken);

        [OperationContract]
        tblANPRMasterDto GetANPRDeviceMasterData(string authToken, long DeviceId);

        [OperationContract]
        tblANPRLPDetailsDTO GetANPRDeviceLPData(string authToken, string AnprDeviceId);

        [OperationContract]
        IEnumerable<SP_GetANPRStatusLabel_ResultDTO> GetANPRVehicleLHSRHSLableData(string authToken);

        [OperationContract]
        IEnumerable<SP_GetOvernightVehicleDetails_ResultDTO> GetOvernightVehicleDetailsCount(string authToken, int flag);

        [OperationContract]
        int GetANPRTransactionID(string authToken, long alertID); //amit 04052018

        [OperationContract]
        IEnumerable<SP_GetNonRegisteredVehicle_ResultDTO> GetANPRUnRegisteredVehicles(string authToken, string startDate, string endDate);

        [OperationContract]
        IEnumerable<tblANPRMasterDto> GetANPRDeviceMasterCollection(string authToken);

        [OperationContract]
        IEnumerable<SP_GetANPRTransactionInfo_ResultDTO> GetANPRDetailDateWise(string authToken, string startDate, string endDate);

        [OperationContract]
        IEnumerable<SP_GetANPRTransactionDetails_ResultDTO> GetANPRTransactionDetails(string authToken, string startDate, string endDate, string aNPRDeviceName, string vehicleNumber, string direction, string accessType);

        [OperationContract]
        IEnumerable<SP_GetVehiclePreset_ResultDTO> GetVehiclePreset(string authToken, string startDate, string endDate, string aNPRDeviceName,  string accessType,string vehicleNumber);

        [OperationContract]
        IEnumerable<SP_GetANPRNonOCRDetails_ResultDTO> GetANPRNonOCRDetails(string authToken, string startDate, string endDate);
    }
}
