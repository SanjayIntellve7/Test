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
        string CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component,string FCMToken);
  
        [OperationContract]
        string CreateWeakSession(string identifier, string systemId, string username);
        [OperationContract]
        bool CloseSession(string authToken, string identifier);

        [OperationContract]  //amit 07122016
        bool LogoutConfig(string authToken, string identifier);

        [OperationContract]
        string GetServerConfigIpAddress(string authToken);
       
    }
}
