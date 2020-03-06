using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IZonesGetOperationService
    {
        [OperationContract]
        IEnumerable<Zone> GetZonesByDeviceId(string authToken, long deviceId);
        
        [OperationContract]
        IEnumerable<SiteDto> GetZones(string authToken);
        
        [OperationContract]
        IEnumerable<SiteDto> GetSites(string authToken);

        [OperationContract]
        IEnumerable<SiteDto> GetAllSites(string authToken);

        [OperationContract]
        IEnumerable<SiteDto> GetSitesList(string authToken);

        [OperationContract]
        byte[] GetSiteMap(string authToken, int siteId);


        [OperationContract]
        IEnumerable<SiteDto> GetAllSitesMosaic();

    }
}
