using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Services;
using System.Collections.Generic;

namespace AMS.Broker.Contracts.Services
{
    public interface IStationCallbackContract
    {
        [OperationContract]
        void ActivatedStation(Station station);

        [OperationContract]
        void DeactivatedStation(int stationId);

        [OperationContract]
        void RefreshStation(Station station);

        [OperationContract]
        void RequestMessage(Message message);

        [OperationContract]
        void RaiseAlert(Alert alert);

        [OperationContract]
        void HaveUpdatedAlert(Alert alert);

        [OperationContract]
        void HaveUpdatedAlerts(AlertsCollection alerts);

        [OperationContract]
        void UserLoggedIn(User user);

        [OperationContract]
        void UserLoggedOut(User user);

        [OperationContract]
        void IncidentReportRaised(Contracts.DTO.IncidentReportWrapper incidentReport);

        [OperationContract]
        void SendOpenAlerts(AlertsCollection alerts);

        [OperationContract]
        void HaveUpdatedGroups();

        [OperationContract]
        void PingStations();

        [OperationContract]
        void InformAboutEvent(Event realTimeEvent);

        [OperationContract(IsOneWay = true)]
        void RaiseSiteAdded(SiteDto site);

        [OperationContract(IsOneWay = true)]
        void RaiseSiteChanged(SiteDto site);

        [OperationContract(IsOneWay = true)]
        void RaiseSiteDeleted(int siteId);

        [OperationContract(IsOneWay = true)]
        void RaiseDeviceAdded(DeviceDto device);

        [OperationContract(IsOneWay = true)]
        void RaiseDeviceChanged(DeviceDto device);

        [OperationContract(IsOneWay = true)]
        void RaiseDeviceDeleted(long deviceId);

        [OperationContract(IsOneWay = true)]
        void RaiseVideoAnalyticsStarted(string cameraGuid);

        [OperationContract(IsOneWay = true)]
        void RaiseVideoAnalyticsStopped(string cameraGuid);

        [OperationContract(IsOneWay = true)]
        void RaiseAlertAcknowledged(Alert alert);

        [OperationContract(IsOneWay = true)]
        void RaiseAlertCanceled(Alert alert);

        [OperationContract(IsOneWay = true)]
        void RaiseAccountSaved(AccountLightDto accountDto);
    }
}