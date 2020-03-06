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
    public interface IStationServiceCommunication
    {
        [OperationContract]
        Station ActivatedStation(string authToken, string identifier);
        [OperationContract]
        void DeactivateStation(string authToken, string identifier);
        [OperationContract]
        Station UpdateRegistionInfoStation(String authToken, String machineIdentifier, String description, String metadata, String longitued, String latitude);
        [OperationContract]
        void SentMessage(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId);
        //amit 08082016
        [OperationContract]
        void SetMosaic(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId);
        [OperationContract]
        void SetStartStopSequence(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId);
        //
        [OperationContract]
        void SendMobileNotification(MobileNotificationData mobData);

        [OperationContract]
        IEnumerable<Station> GetStationsCollection(string authToken, bool includeInactive = false);
        [OperationContract]
        void DeactivateStationByIdentifier(string identifier);
        [OperationContract]
        bool RegisterStation(string authToken, string identifier, string type, string description, string metadata, string longitued = null, string latitude = null);
    }
}
