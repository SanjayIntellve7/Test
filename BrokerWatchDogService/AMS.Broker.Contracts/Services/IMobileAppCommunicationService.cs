using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using IncidentReportDTO = AMS.Broker.Contracts.DTO.IncidentReport;
using System.IO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IMobileAppCommunicationService
    {
        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionMobSiteId(string authToken, long siteId); //
       
        [OperationContract]
        IEnumerable<AlertMobDto> GetMobileSingleAlert(string authToken, int alertID);//

        [OperationContract]
        IEnumerable<SiteDto> GetAllSites(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionMob(string authToken);

        [OperationContract]
        string GetRepositoryConfiguration(string authToken);  //trupti09112015

        [OperationContract]
        IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken);

        [OperationContract]
        string GetMobCurrentOpenAlertsCount(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetCurrentOpenAlerts(string authToken);      

        [OperationContract]
        bool AcknowledgeAlertsMobile(string authToken,string alerts);

        [OperationContract]
        bool CancelAlertsMobile(string alerts);

        [OperationContract]
        Boolean CreateMobileAlert(string urgency, string severity,string certainty, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No);

        [OperationContract]
        bool UpdateMobileAlert(string alertId, string retPath, string retVoicenotePath, string retVideoPath);

        [OperationContract]//(Name = "RegisterStation")]
        Boolean RegisterStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);

        [OperationContract]//(Name = "ActivateStation")]
        Station ActivateStation(String authToken, String identifier);

         [OperationContract]
        Station ActivateWebClient(string authToken, string identifier);

        [OperationContract]//(Name = "DeactivateStation")]
        void DeactivateStation(String authToken, String identifier);

        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportsByOwnerWeb(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName);

        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);

        [OperationContract]
        bool CreateDummySimulatorAlerts(string alertcode);

        [OperationContract]
        bool AnimateMapPin();

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionWeb(string authToken);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        int ChangePasswordNew(string username, string oldPassword, string newPassword); //amit 27092017// jatin 06012017

        //saurabh changes for mobile app 16112017
        [OperationContract] //saurabh 13112017 //amit 10/10/2017
        DeviceDto GetDeviceById(string authToken, long deviceId);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaPic(Stream strData);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaAudio(Stream strData);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaVideo(Stream strData);

        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportsByOwnerWebMob(string authToken);

        [OperationContract]
        bool Test();
        //
    }
}
