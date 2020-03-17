using System;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using UserLocationDTO = AMS.Broker.Contracts.DTO.UserLocation;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace="http://2020.AMS")]
    public interface IUsersGetOperationService
    {
        [OperationContract(Name="GetActiveUsers")]
        IEnumerable<User> GetActiveUsers(string authToken);

        [OperationContract(Name="GetUsersList")]
        IEnumerable<User> GetUsersList(string authToken);

        [OperationContract(Name = "GetUsersTypesList")]
        IEnumerable<UserTypeDto> GetUserTypes(string authToken);

        [OperationContract(Name="GetUsersListByAlertGroup")]
        NotifyList GetUsersListByAlertGroup(AlertStatusWrapper content);        

        [OperationContract(Name = "GetUserLocations")]
        IEnumerable<UserLocationDTO> GetUserLocations(string userName);

        
        [OperationContract(Name = "GetUsersLocations")]
        IEnumerable<UserLocationDTO> GetUsersLocations();

        [OperationContract(Name = "GetUserSiteDetails")]
        SiteDto GetUserSiteDetails(int UserId, string authToken); //trupti 27 Aug 15


    }
}
