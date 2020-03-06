using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AMS.Broker.WatchDogServiceTests.TestUsersService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMS.Broker.WatchDogServiceTests
{
    [TestClass]
    public class TestUserService
    {
        [TestMethod]
        public void TestAddUserLocation()
        {
            var usersServiceClient = new UsersServiceClient();

            var userLocation = new UserLocation {Alt = 0, IsFavorite = true, Lat = 0, Long = 0, Username = "Victor"};
            usersServiceClient.AddUserLocation(userLocation);
            var userLocation2 = new UserLocation { Alt = 1, IsFavorite = false, Lat = 1, Long = 1, Username = "Victor2" };
            usersServiceClient.AddUserLocation(userLocation2);
        }

        [TestMethod]
        public void TestGetUserLocations()
        {
            var usersServiceClient = new UsersServiceClient();

            UserLocationsCollection collection = usersServiceClient.GetUserLocations("victor");

            int i = 1;

        }

        [TestMethod]
        public void TestDeleteUserLocations()
        {
            var usersServiceClient = new UsersServiceClient();

            UserLocationsCollection collection = usersServiceClient.GetUserLocations("victor");

            int i = 1;

        }

        [TestMethod]
        public void TestSetFavoriteUserLocations()
        {
            var usersServiceClient = new UsersServiceClient();

            UserLocationsCollection userLocationsCollection = usersServiceClient.GetUserLocations("victor");

            usersServiceClient.SetUserLocationAsDefault(userLocationsCollection.Items[0]);

            int i = 1;

        }
    }
}
