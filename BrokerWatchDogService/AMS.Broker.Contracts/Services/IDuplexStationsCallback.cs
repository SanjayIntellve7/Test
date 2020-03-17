using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{

    public interface IDuplexStationsCallback
    {
        [OperationContract(IsOneWay = true)]
        void Inform(string result);

        [OperationContract(IsOneWay = true)]
        void InformTwo(string result, string strTwo);

        [OperationContract]
        void RefreshStation(string stationContent);//
        [OperationContract]
        void DeactivatedStation(int stationId);
        [OperationContract]
        void ActivatedStation(string stationContent);
        [OperationContract]
        void DeviceStartRequest(int winId, String content);
        [OperationContract]
        void UserLoggedIn(string userContent);
        [OperationContract]
        void UserLoggedOut(string userContent);
        [OperationContract]
        void RaiseAlert(string alertContent, string OldOwner = null); //trupti 07 April 2016
        [OperationContract]
        void RaiseAlertAssigned(string alert);

        [OperationContract]
        void ResetPidsSytemAlert(int AlertID, string Status);

        [OperationContract]
        void ClearPidsSytemAlert(int AlertID);

        [OperationContract]
        void OnSOPExecute(string alert);

        [OperationContract]
        void OnOpenNearByCamera(string siteid);

        [OperationContract]
        void RaiseAlertCollabrate(string alert);

        [OperationContract]
        void RaiseCapProfileUpdate(string alert);

        [OperationContract]
        void HaveUpdatedAlerts(string alerts);
        [OperationContract]
        void IncidentReportRaised(string incidentReport);
        [OperationContract]
        void SendOpenAlerts(string alerts);
        /* [OperationContract]
         void HaveUpdatedGroups();*/
        /*[OperationContract]
        void HaveUpdatedAlert(Alert alert);*/
        [OperationContract]
        void InformAboutEvent(string realTimeEvent);
        [OperationContract]
        void RaiseSiteAdded(string site);
        [OperationContract]
        void RaiseSiteChanged(string site);
        [OperationContract]
        void RaiseSiteDeleted(int siteId);
        [OperationContract]
        void RaiseDeviceAdded(string device);
        [OperationContract]
        void RaiseDeviceChanged(string device);
        [OperationContract]
        void RaiseDeviceDeleted(int deviceId);
        [OperationContract]
        void RaiseVideoAnalyticsStarted(string cameraGuid);
        [OperationContract]
        void RaiseCamBookMarkadded(string cameraGuid);
        [OperationContract]
        void RaiseVideoAnalyticsStopped(string cameraGuid);
        [OperationContract]
        void RaiseAlertAcknowledged(string alert);
        [OperationContract]
        void RaiseAlertCanceled(string alert);
        [OperationContract]
        void RaiseAccountSaved(string accountDto);
        [OperationContract]
        int CheckStatus();

        [OperationContract]
        void RefreshAlert(string stationContent);//

        //trupti20112015
        //[OperationContract]
        //int TrackingWithCamera();
        //
        [OperationContract]
        void RaiseCloseAllAlert(string DeviceId);

        [OperationContract]
        void RaiseLineCountEvent(string DeviceId, string count, string funtion);

        [OperationContract]
        void RaiseAlertEscallation(string Message, string AlertId);

        [OperationContract]
        string SendDataToBroker(string clientName, string macAddress); //harsha 17082018

        ////for mosaic
        [OperationContract]
        void DeviceStartRequestMosaic(int winId, String content, string fixCamera, string matrixSize, string sequenceNumber, string reserve1);

        [OperationContract]
        void SetMosaic1(int winId, String content, string fixCamera, string matrixSize, string sequenceNumber, string reserve1);

        [OperationContract]
        void StartStopSequence(int winId, String content);

        [OperationContract]
        bool StartInaugrationProcess(string Message, int Timer);

        ////
    }
}
