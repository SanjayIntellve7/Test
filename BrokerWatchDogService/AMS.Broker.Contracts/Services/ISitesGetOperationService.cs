using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISitesGetOperationService
    {
        #region SiteTypes

        [OperationContract]
        SiteTypeDto GetSiteType(int siteTypeId);

        [OperationContract]
        List<SiteTypeDto> GetSiteTypes(string authToken);
       

        #endregion

        #region BBoxPoints

        [OperationContract]
        BBoxPointDto GetBBoxPoint(int bboxPointId);

        [OperationContract]
        List<BBoxPointDto> GetBBoxPointsBySite(int siteId);

       

        #endregion

        #region Sites

        [OperationContract]
        SiteDto GetSite(int siteId,string authToken);

        [OperationContract]
        SiteDto GetSiteConfig(int siteId, string authToken); //trupti090818

        [OperationContract]
        SiteDto GetSiteByName(string name, string authToken);

        [OperationContract]
        List<SiteDto> GetSites(string authToken);

        [OperationContract]
        List<SiteDto> GetSiteForAccount(int accountId, string username, string authToken);

        [OperationContract]
        List<SiteDto> GetChildSites(int parentSiteId,string authToken);

        [OperationContract]
        List<SiteDto> GetChildSitesConfig(int parentSiteId, string authToken);  //trupti090818

       
        [OperationContract]
        bool HasSites(int accountId, string authToken);

        //trupti 27 Aug 15
        [OperationContract]
        List<SiteDto> GetOnlySite(string authToken);

        [OperationContract]
        bool GetCustomMapFromDB();

        #endregion

    }
}
