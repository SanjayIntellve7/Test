using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IGetMobileOperationService
    {
        [OperationContract]
        bool DoWork();

        [OperationContract]
        IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken);

        [OperationContract]
        IEnumerable<AlertMobDto> GetMobileSingleAlert(string authToken, int alertID);

        [OperationContract]
        IList<AssociatedDevicesDto> GetAssociatedDeviceCollectionMob(string authToken, string DeviceId);

        [OperationContract]
        NvrDto GetNvrById(string authToken, long nvrId);

        [OperationContract]
        IList<string> GetPlaybackRecordsURL(long alertId, long deviceId, string StartTime, string StopTime);

        [OperationContract]
        string GetUserRole(string authToken);

        [OperationContract]
        DeviceDto GetDeviceById(string authToken, long deviceId);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionMobSiteId(string authToken, long siteId);

        [OperationContract]
        string GetRepositoryConfiguration(string authToken);  //trupti09112015

        [OperationContract]
        string[] GetImageFileNames(string AlertID);

        [OperationContract]
        string[] GetAudioFileNames(string AlertID);

        [OperationContract]
        string[] GetVideoFileNames(string AlertID);

        [OperationContract(Name = "GetIncidentReportByIDWeb")]
        List<IncidentReportWrapper> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);

        [OperationContract]
        List<IncidentReport> GetIncidentReportsByOwnerWebMob(string authToken); // saurabh 08032018

        [OperationContract]
        string[] GetIRImageEvidence(string ResourceID, string CreationDate);

        [OperationContract]
        string[] GetIRVideoEvidence(string ResourceID, string CreationDate);

        [OperationContract]
        string[] GetIRFileEvidence(string ResourceID, string CreationDate);

        [OperationContract]
        string GetIRAlertEvidence(string ResourceID, string CreationDate);

        [OperationContract]
        bool IsAlertAttached(long IrID, long alertid, string authToken); //amit 03072015

        [OperationContract]
        IEnumerable<SPSearch_Mob_ResultDto> GetContextAlertDataMobile(string Context, string Component, bool IsDateFilter, string StartDate, string EndDate, string AuthToken);//jatin 19032018

        [OperationContract]
        DeviceDto GetSingleDeviceDetails(string authToken, long deviceId);

        [OperationContract]
        IEnumerable<SiteDto> GetAllSitesMobile(string authToken);

        [OperationContract]
        List<IncidentEvidenceInfoDTO> GetAttachedMobileEvidences(string authToken, long AlertID, string Component);

        [OperationContract]
        string GetIRFileEvidenceName(string ResourceID, string CreationDate);

        //[OperationContract]
        //List<IncidentEvidenceInfoDTO> GetAttachedAlertEvidences(string authToken, long AlertID);
    }
}
