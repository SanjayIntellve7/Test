using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IClientService
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
    }
}
