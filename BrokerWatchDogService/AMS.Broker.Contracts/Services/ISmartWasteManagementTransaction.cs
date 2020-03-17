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
    public interface ISmartWasteManagementTransaction
    {
        [OperationContract]
        bool Call();
        [OperationContract]
        string ConsumeBinFullAlert(SWMBinFullDTO EventData);
        [OperationContract]
        string ConsumeFullBinPickedUpAlert(SWMFullBinPickedUpAlertDto EventData);
        [OperationContract]
        List<tblSWMBinMasterDTO> GetBinMasterData();
        [OperationContract]
        List<tblSWMVehicleMasterDTO> GetBinVehicleMaster();
        [OperationContract]
        List<SWMVehicleLastTxnDetailsDto> GetLatestVehicleBinTransaction();
        [OperationContract]
        List<tblSWMVehicleTXDataDTO> GetVehicleRouteData(long deviceID, string ExternalID, string StartDate, string EndDate);
        [OperationContract]
        string CitizenGrievanceAlert(GrievanceAlertData AlertData);

        [OperationContract]
        string CitizenGrievanceClosedAlert(GrievanceClosedAlertData ClosedAlertData);

        [OperationContract]
        void StartSWMTxnThreads();
    }
}
