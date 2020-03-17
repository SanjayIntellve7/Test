using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISitesSetOperationService
    {
        [OperationContract]
        SiteTypeDto AddSiteType(SiteTypeDto siteTypeToAdd);

        [OperationContract]
        SiteTypeDto UpdateSiteType(SiteTypeDto siteTypeToUpdate);

        [OperationContract]
        bool DeleteSiteType(int siteTypeId);

        [OperationContract]
        BBoxPointDto AddBBoxPoint(BBoxPointDto bboxPointToAdd, SiteDto site);

        [OperationContract]
        BBoxPointDto UpdateBBoxPoint(BBoxPointDto bboxPointToUpdate);

        [OperationContract]
        bool DeleteBBoxPoint(int bboxPointId);

        [OperationContract]
        SiteDto AddSite(SiteDto siteToAdd, SiteTypeDto siteType, SiteDto parentSite, AddressDto address, AccountDto account, List<BBoxPointDto> bboxPoints, List<tblcustomeremergencycontactDTO> emergencyContactlist, string authToken);

        [OperationContract]
        SiteDto UpdateSite(SiteDto siteToUpdate,List<tblcustomeremergencycontactDTO> EmergencyContactCollection, string authToken);

        [OperationContract]
        bool DeleteSite(SiteDto siteToDelete, string authToken);

        [OperationContract]
        SiteDto SetSiteBBox(SiteDto site, List<BBoxPointDto> bboxPoints);

        [OperationContract]
        string GetCameraUrlTest(long DeviceId, string type, string StartTime, string StopTime);

        [OperationContract]
        ImportSiteInsertStatuscs SaveImportSiteList(List<SiteDto> AllSiteList, SiteDto parentSite, AccountDto account, string authToken);//komal10012020
    }
}
