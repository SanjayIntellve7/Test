using AMS.Broker.Contracts.DTO;
using System;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAuthService
    {
        /// <summary>
        /// Creates Monitor registration in the system.
        /// </summary>
        /// <param name="systemId">A system identyfication</param>
        /// <param name="username">username for partiucular system</param>
        /// <param name="password">password for a user</param>
        /// <returns>Guid which is a session id, null otherwise.</returns>      
        [OperationContract]
        string CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component, string FCMToken);
        [OperationContract]
        string CreateWeakSession(string identifier, string systemId, string username);
        [OperationContract]
        bool CloseSession(string authToken, string identifier);

        [OperationContract]  //amit 07122016
        bool LogoutConfig(string authToken, string identifier);

        [OperationContract]
        string GetServerConfigIpAddress(string authToken);

        [OperationContract]
        string TestCommunication();

        [OperationContract]//(Name = "ActivateStation")]
        Station ActivateStation(String authToken, String identifier);

        [OperationContract]//(Name = "DeactivateStation")]
        void DeactivateStation(String authToken, String identifier);

        [OperationContract]//(Name = "RegisterStation")]
        Boolean RegisterStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);

        [OperationContract]
        string CreateSessionForADUser(string identifier, string systemId, string username, string password, string identifierIP, string component, string FCMToken);//komal 31052019
        [OperationContract]
        string CheckLockedADUser(string username, string password);//komal 31052019
    }
}
