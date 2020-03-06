using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISitesService
    {
        #region SiteTypes

        [OperationContract]
        SiteTypeDto GetSiteType(int siteTypeId);

        [OperationContract]
        List<SiteTypeDto> GetSiteTypes();

        [OperationContract]
        SiteTypeDto AddSiteType(SiteTypeDto siteTypeToAdd);

        [OperationContract]
        SiteTypeDto UpdateSiteType(SiteTypeDto siteTypeToUpdate);

        [OperationContract]
        bool DeleteSiteType(int siteTypeId);

        #endregion

        #region BBoxPoints

        [OperationContract]
        BBoxPointDto GetBBoxPoint(int bboxPointId);

        [OperationContract]
        List<BBoxPointDto> GetBBoxPointsBySite(int siteId);

        [OperationContract]
        BBoxPointDto AddBBoxPoint(BBoxPointDto bboxPointToAdd, SiteDto site);

        [OperationContract]
        BBoxPointDto UpdateBBoxPoint(BBoxPointDto bboxPointToUpdate);

        [OperationContract]
        bool DeleteBBoxPoint(int bboxPointId);

        #endregion

        #region Sites

        [OperationContract]
        SiteDto GetSite(int siteId);

        [OperationContract]
        SiteDto GetSiteByName(string name);

        [OperationContract]
        List<SiteDto> GetSites();

        [OperationContract]
        List<SiteDto> GetSiteForAccount(int accountId, string username);

        [OperationContract]
        List<SiteDto> GetChildSites(int parentSiteId);

        [OperationContract]
        SiteDto AddSite(SiteDto siteToAdd, SiteTypeDto siteType, SiteDto parentSite, AddressDto address, AccountDto account, List<BBoxPointDto> bboxPoints);

        [OperationContract]
        SiteDto UpdateSite(SiteDto siteToUpdate);

        [OperationContract]
        bool DeleteSite(SiteDto siteToDelete);

        [OperationContract]
        SiteDto SetSiteBBox(SiteDto site, List<BBoxPointDto> bboxPoints);

        [OperationContract]
        bool HasSites(int accountId);

        //trupti 27 Aug 15
        [OperationContract]
        List<SiteDto> GetOnlySite();

        [OperationContract]
        bool GetCustomMapFromDB();

        #endregion

    }
}
