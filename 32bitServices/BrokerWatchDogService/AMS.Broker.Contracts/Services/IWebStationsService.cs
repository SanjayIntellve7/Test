using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IWebStationsService
    {
        [OperationContract]
        bool Test();

        /// <summary>
        /// Allows to add a new station or to activate allready registred
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Boolean RegisterStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);
        [OperationContract]
        Boolean UpdateRegistionInfoStation(String authToken, String identifier, String description, String metadata, String longitued, String latitude);
        [OperationContract]
        Boolean ActivateStation(String authToken, String identifier);
        [OperationContract]
        void DeactivateStation(String authToken, String identifier);

        [OperationContract]
        void SentMessage(String authToken, Int32 stationId, Int32 monitorId, String type, String content, Int32 fromStationId, string fixCamera, string reserve1);

        [OperationContract]
        IEnumerable<Station> GetStaionsCollection(String authToken, bool includeInactive = false);

        [OperationContract]
        IEnumerable<String> GetMessagesCollection(String authToken, String timestamp);
        
    }
}
