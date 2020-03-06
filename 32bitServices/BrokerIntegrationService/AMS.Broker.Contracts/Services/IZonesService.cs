using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IZonesService
    {
        [OperationContract]
        IEnumerable<Zone> GetZonesByDeviceId(string authToken, long deviceId);

        [OperationContract]
        bool AddZone(string zone);

        [OperationContract]
        bool DeleteZone(Guid authToken, long zoneId);

        [OperationContract]
        IEnumerable<SiteDto> GetZones(string authToken);
        [OperationContract]
        bool UpdateZone(string zone);

        [OperationContract]
        long AddZoneLocation(Guid authToken, string zoneLocation);

        [OperationContract]
        bool UpdateZoneLocation(Guid authToken, string zoneLocation);

        [OperationContract]
        bool DeleteZoneLocation(Guid authToken, long zoneLocationId);

        [OperationContract]
        IEnumerable<SiteDto> GetSites(string authToken);

        [OperationContract]
        IEnumerable<SiteDto> GetAllSites(string authToken);

        [OperationContract]
        IEnumerable<SiteDto> GetSitesList(string authToken);

        [OperationContract]
        bool AddSites(string authToken, string site);

        [OperationContract]
        byte[] GetSiteMap(string authToken, int siteId);
    }
}
