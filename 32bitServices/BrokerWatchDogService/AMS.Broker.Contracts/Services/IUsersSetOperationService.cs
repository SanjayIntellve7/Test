using System;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using UserLocationDTO = AMS.Broker.Contracts.DTO.UserLocation;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace = "http://2020.AMS")]
    public interface IUsersSetOperationService
    {
        [OperationContract(Name = "AddUserLocation")]
        string AddUserLocation(string userLocation, string authToken);

        [OperationContract(Name = "UpdateUserLocation")]
        UserLocationDTO UpdateUserLocation(string userLocation);

        [OperationContract(Name = "AddUserLocationCollection")]
        void AddUserLocationCollection(string userLocations);

        [OperationContract(Name = "SetUserLocationAsDefault")]
        void SetUserLocationAsDefault(string userLocationFavorite);

        [OperationContract(Name = "DeleteUserLocationCollection")]
        void DeleteUserLocationCollection(string userLocationsCollection);

        [OperationContract(Name = "DeleteUserLocation")]
        void DeleteUserLocation(string userLocation, string authToken);

        [OperationContract(Name = "UpdateUserSite")]
        bool UpdateUserSite(int userId, int siteId, string userTypeName, string authToken); //trupti 27 Aug 15

        [OperationContract(Name = "AddUserSite")]
        bool AddUserSite(int userId, int siteId, string userTypeName, string authToken); //trupti 27 Aug 15

        void DeleteUserLocation(UserLocationDTO userLocation, string authToken);

        void SetUserLocationAsDefault(UserLocationDTO userLocationFavorite, string authToken);
    }
}
