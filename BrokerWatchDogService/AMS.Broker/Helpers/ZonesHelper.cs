using System;
using System.Linq;
using System.Collections.Generic;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.WatchDogService.DataStore;

using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using ContactMethod = AMS.Broker.Contracts.DTO.ContactMethod;

namespace AMS.Broker.WatchDogService.Helpers
{
    public static class ZonesHelper
    {
        public static NotifyList GetUsersListByZoneCollection(AlertDTO alert, IEnumerable<long> zoneIdsCollection, bool getInherited = false)
        {
            var usersCollection = new List<UserContactInformation>();

            var extendedZoneIdCollections = new List<long>(128);

            using (var ctx = new CentralDBEntities())
            {
                if (getInherited)
                {
                    foreach (var zoneId in zoneIdsCollection)
                        extendedZoneIdCollections.AddRange(GetParentZoneId(ctx, zoneId));
                }

                foreach (var zoneId in extendedZoneIdCollections.Distinct())
                {
                    var zoneUsersCollection = ctx.ZoneUser
                        .Where(x => x.ZoneId == zoneId)
                        .Select(x => x.Username)
                        .ToList()
                        .Where(x => !usersCollection.Any(y => y.Username == x));

                    usersCollection.AddRange(
                        zoneUsersCollection.Select(x => new UserContactInformation
                        {
                            Username = x,
                            ContactMethodsCollection = GetContactMethods(x)
                        })
                    );
                }
            }

            return new NotifyList
            {
                Alert = alert,
                UsersCollection = usersCollection.ToArray()
            };
        }

        private static IEnumerable<long> GetParentZoneId(this CentralDBEntities ctx, long zoneId)
        {
            var parentZoneIds = ctx.ZoneGroup.Where(x => x.ZoneId == zoneId).Select(x => x.ParenZoneId);
            var currentZoneCollection = new List<long>();

            currentZoneCollection.Add(zoneId);

            foreach (var zone in parentZoneIds)
                currentZoneCollection.AddRange(GetParentZoneId(ctx, zone));

            return currentZoneCollection;
        }

        private static ContactMethod[] GetContactMethods(string x)
        {
            var userPrincipal = AuthenticationHelper.GetUsersByUsername(x);

            return new ContactMethod[]
            {
                new ContactMethod{ Name = "sid", Value = userPrincipal.Sid.ToString() },
                new ContactMethod{ Name = "email", Value = userPrincipal.EmailAddress },
                new ContactMethod{ Name = "phone", Value = userPrincipal.VoiceTelephoneNumber }
            };
        }
    }
}
