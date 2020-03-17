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
    public interface IAuthMobileOperationService
    {

        [OperationContract]//(Name = "ActivateStation")]
        Station ActivateStation(string authToken, string identifier);

        [OperationContract]
        string CreateSession(string identifier, string systemId, string username, string password, string identifierIP, string component, string FCMToken = null);

        [OperationContract]
        void DeactivateStation(string authToken, string identifier);
    }
}

