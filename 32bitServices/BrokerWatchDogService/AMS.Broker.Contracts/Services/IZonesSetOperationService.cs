using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IZonesSetOperationService
    {
        [OperationContract]
        bool AddZone(string zone);

        [OperationContract]
        bool DeleteZone(Guid authToken, long zoneId);

        [OperationContract]
        bool UpdateZone(string zone);

        [OperationContract]
        long AddZoneLocation(Guid authToken, string zoneLocation);

        [OperationContract]
        bool UpdateZoneLocation(Guid authToken, string zoneLocation);

        [OperationContract]
        bool DeleteZoneLocation(Guid authToken, long zoneLocationId);

        [OperationContract]
        bool AddSites(string authToken, string site);

    }
}
