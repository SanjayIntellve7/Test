using System;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using UserLocationDTO = AMS.Broker.Contracts.DTO.UserLocation;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace="http://2020.AMS")]
    public interface IUsersService
    {
        [OperationContract(Name="GetActiveUsers")]
        IEnumerable<User> GetActiveUsers(string authToken);

        [OperationContract(Name="GetUsersList")]
        IEnumerable<User> GetUsersList(string authToken);

        [OperationContract(Name = "GetUsersTypesList")]        
        IEnumerable<UserTypeDto> GetUserTypes(string authToken);

        [OperationContract(Name="GetUsersListByAlertGroup")]
        NotifyList GetUsersListByAlertGroup(AlertStatusWrapper content);

        [OperationContract(Name = "AddUserLocation")]
        string AddUserLocation(string userLocation);

        [OperationContract(Name = "UpdateUserLocation")]
        UserLocationDTO UpdateUserLocation(string userLocation);

        [OperationContract(Name = "AddUserLocationCollection")]
        void AddUserLocationCollection(string userLocations);

        [OperationContract(Name = "GetUserLocations")]
        IEnumerable<UserLocationDTO> GetUserLocations(string userName);

        [OperationContract(Name = "SetUserLocationAsDefault")]
        void SetUserLocationAsDefault(string userLocationFavorite);

        [OperationContract(Name = "DeleteUserLocationCollection")]
        void DeleteUserLocationCollection(string userLocationsCollection);

        [OperationContract(Name = "DeleteUserLocation")]
        void DeleteUserLocation(string userLocation);

        [OperationContract(Name = "GetUsersLocations")]
        IEnumerable<UserLocationDTO> GetUsersLocations();

        [OperationContract(Name = "UpdateUserSite")]
        bool UpdateUserSite(int userId, int siteId, string userTypeName); //trupti 27 Aug 15

        [OperationContract(Name = "AddUserSite")]
        bool AddUserSite(int userId, int siteId, string userTypeName); //trupti 27 Aug 15

        [OperationContract(Name = "GetUserSiteDetails")]
        SiteDto GetUserSiteDetails(int UserId); //trupti 27 Aug 15


        void DeleteUserLocation(UserLocationDTO userLocation);

        void SetUserLocationAsDefault(UserLocationDTO userLocationFavorite);


    }
}
