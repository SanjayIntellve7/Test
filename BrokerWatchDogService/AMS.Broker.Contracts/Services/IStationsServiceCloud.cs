using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDuplexStationsCallback))]
    public interface IStationsServiceCloud
    {

        [OperationContract()]
        string Heartbeat();

        [OperationContract(IsOneWay = true)]
        void Subscribe(string stationId);

        [OperationContract(IsOneWay = true)]
        void Unsubscribe(string stationId);

        [OperationContract]
        bool Test();

        /// <summary>
        /// Allows to add a new station or to activate allready registred
        /// </summary>
        /// <returns></returns>
        [OperationContract]//(Name = "RegisterStation")]
        Boolean RegisterStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);

        [OperationContract]//(Name = "UpdateRegistionInfoStation")]
        Station UpdateRegistionInfoStation(String authToken, String identifier, String description, String metadata, String longitued, String latitude);

        [OperationContract]//(Name = "ActivateStation")]
        Station ActivateStation(String authToken, String identifier);

        [OperationContract]//(Name = "ActivateStation")]
        Station ActivateMosaicStation(String authToken, String identifier, String siteID);

        [OperationContract]//(Name = "DeactivateStation")]
        void DeactivateStation(String authToken, String identifier);

        [OperationContract]//(Name = "DeactivateStationByIdentifier")]
        void DeactivateStationByIdentifier(String identifier);

        [OperationContract]//(Name = "SentAlertToStation")]
        Boolean SentAlertToStation(string userSID, Alert alert);

        [OperationContract]//(Name = "SentMessage")]
        void SentMessage(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId, string fixCamera, string reserve1);
        //amit 08082016
        [OperationContract]//(Name = "SetMosaic")]
        void SetMosaic(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId, string fixCamera, string matrixSize, string sequenceNumber, string reserve1);

        [OperationContract]//(Name = "SetStartStopSequence")]
        void SetStartStopSequence(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId);
        //

        [OperationContract]//(Name = "SendMobileNotification")]
        void SendMobileNotification(MobileNotificationData mobData);

        [OperationContract]//(Name = "GetStationsCollection")]
        IEnumerable<Station> GetStationsCollection(String authToken, bool includeInactive = false);

        [OperationContract]//(Name = "InformAboutRaisedAlerts")]
        void InformAboutRaisedAlerts(Alert alertDto);

        [OperationContract]//(Name = "InformAboutRaisedAlertsNew")]
        void InformAboutRaisedAlertsNew(AlertDTO alertDto, string OldOwner); //trupti 07042016

        [OperationContract]//(Name = "InformAboutCollabrateAlerts")]
        void InformAboutCollabrateAlerts(AlertDTO alertDto);

        [OperationContract]//(Name = "InformAboutRaisedAlertsAssigned")]
        void InformAboutRaisedAlertsAssigned(AlertDTO alertDto);

        [OperationContract]//(Name = "InformCapProfileUpdate")]
        void InformCapProfileUpdate(AlertDTO alertDto);

        [OperationContract]//(Name = "InformAboutUserLoggedIn")]
        void InformAboutUserLoggedIn(User user);

        [OperationContract]//(Name = "InformAboutUserLoggedOut")]
        void InformAboutUserLoggedOut(User user);

        [OperationContract]//(Name = "InformAboutAlertUpdate")]
        void InformAboutAlertUpdate(Alert alert);

        [OperationContract]//(Name = "InformAboutAlertsUpdate")]
        void InformAboutAlertsUpdate(IEnumerable<Alert> alerts);

        [OperationContract]//(Name = "InformAboutAcknowledgedAlert")]
        void InformAboutAcknowledgedAlert(Alert alert);

        [OperationContract]//(Name = "InformAboutCanceledAlert")]
        void InformAboutCanceledAlert(Alert alert);

        [OperationContract]//(Name = "NotifyNewOwnerOfIncidentReport")]
        bool NotifyNewOwnerOfIncidentReport(string userSID, Contracts.DTO.IncidentReportWrapper incidentReport);

        void SentOpenAlertsToStation(Alert[] alerts);

        [OperationContract]//(Name = "InformUpdatedGroups")]
        void InformUpdatedGroups();

        [OperationContract]//(Name = "NotifyNewOwnerOfIncidentReportCollabrotion")]
        bool NotifyNewOwnerOfIncidentReportCollabrotion(string userSID, IncidentReportWrapper incidentReport);

        [OperationContract]//(Name = "CheckStationsStatus")]
        void CheckStationsStatus();

        [OperationContract]//(Name = "InformCamBookMarkadd")]  //trupti280116
        void InformCamBookMarkadd(string cameraGuid);

        [OperationContract]
        void InformCurrentClimateAlert(tblweatherchcurrentDTO _CurrentData);

        [OperationContract]
        void InformForecastClimateAlert(List<tblWeatherhourlyforecastDTO> _forecastData);

        [OperationContract]//(Name = "InformAboutAcknowledgedAlert")]
        void InformAboutPAAnnounce(Alert alert);

        [OperationContract]//(Name = "InformAboutAcknowledgedAlert")]
        void InformAboutOpenNearByCameras(string siteID);

        [OperationContract]//(Name = "SentMessage")]
        bool SentMessageStation(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId);


        #region Account Events

        [OperationContract]//(Name = "InformAccountSaved")]
        void InformAccountSaved(AccountLightDto accountDto);

        #endregion

        #region Site Events

        [OperationContract]//(Name = "InformAboutSiteChanged")]
        void InformAboutSiteChanged(SiteDto site);

        [OperationContract]//(Name = "InformAboutSiteAdded")]
        void InformAboutSiteAdded(SiteDto site);

        [OperationContract]//(Name = "InformAboutSiteDeleted")]
        void InformAboutSiteDeleted(int siteId);

        #endregion

        #region Device Events

        [OperationContract]//(Name = "InformDeviceAdded")]
        void InformDeviceAdded(DeviceDto deviceDto);

        [OperationContract]//(Name = "InformDeviceSaved")]
        void InformDeviceSaved(DeviceDto deviceDto);

        [OperationContract]//(Name = "InformDeviceRemoved")]
        void InformDeviceRemoved(long deviceId);

        #endregion

        #region Video Analytics Events

        [OperationContract]//(Name = "InformVideoAnalyticsStarted")]
        void InformVideoAnalyticsStarted(string cameraGuid);

        [OperationContract]//(Name = "InformVideoAnalyticsStopped")]
        void InformVideoAnalyticsStopped(string cameraGuid);

        #endregion

        [OperationContract]//(Name = "PongBroker")]
        void PongBroker();

        void PingStations(object state);

        [OperationContract]
        void InformStationsAboutEvent(Event realTimeEvent);

        [OperationContract]
        bool InformCloseAllAlert(string _deviceId);

        [OperationContract] //amit 17112016 
        void AddMeonCustomer(DeviceDto deviceDto, int escallationID);

        [OperationContract]
        string TestCommunication();


       
    }
}
