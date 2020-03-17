using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IFFTTransactionService
    {
        [OperationContract]
        void GetFFTController(string siteID, string InterfaceID);

        [OperationContract]
        void UpdateFFTController(string siteID, string InterfaceID);

        [OperationContract]
        void GetFFTZone();

        [OperationContract]
        void GetFFTSensor();

        [OperationContract]
        void GetIsolations();

        [OperationContract]
        bool AcknowledgeFFTAlert(string alarmID);

        [OperationContract]
        bool GetFFTControllerStatus(string authToken, string ControllerID);

        [OperationContract]
        IList<FFTControllerStatus> GetFFTControllerStatusCollection(string authToken);

        [OperationContract]
        void ConsumeFFTAlert(FFTCreateAlarmParamDto _FFTCreateAlarmParamDto);

        [OperationContract]
        void ClearFFTAlert(long alarmID);

        [OperationContract]
        void ResetZoneAlarm(int zoneID, string status);
    }
}
