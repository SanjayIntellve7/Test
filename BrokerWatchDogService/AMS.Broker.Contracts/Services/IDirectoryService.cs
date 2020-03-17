using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IDirectoryService
    {
        [OperationContract(Name = "AddGroup")]
        void AddGroup(string authToken, string groupName);
        [OperationContract(Name = "RemoveGroup")]
        void RemoveGroup(string authToken, string groupName);
        [OperationContract(Name = "GetUsersByGroup")]
        IEnumerable<string> GetUsersByGroup(string authToken, string groupName);
        [OperationContract(Name = "AddUserToGroup")]
        void AddUserToGroup(string authToken, string userName, string groupName);
    }
}
