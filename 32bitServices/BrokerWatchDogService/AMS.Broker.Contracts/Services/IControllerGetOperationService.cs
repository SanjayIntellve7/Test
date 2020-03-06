using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IControllerGetOperationService
    {

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollection(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionMob(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionWeb(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionMobSiteId(string authToken, long siteId);

        [OperationContract]
        IEnumerable<AccountDto> GetAccountsCollection(string authToken);

        [OperationContract]
        IEnumerable<ContactDto> GetContactsCollection(string authToken);

        [OperationContract]
        IEnumerable<tblDisasterManagementDTO> GetDisasterDataCollection(string authToken);

        [OperationContract]
        IEnumerable<tblSmartCityStreetLightDTO> GetElectriLightDataCollection(string authToken);

        [OperationContract]
        IEnumerable<tblSmartCityStreetElecDTO> GetElectritionDataCollection(string authToken);

        [OperationContract]
        IList<ResourceData> GetAttachResourceCollection(string authToken);
     
        //  [OperationContract]
        //  IEnumerable<DeviceDto> GetEdgeDevicesCollection(string authToken);

        [OperationContract]
        bool Test();

        [OperationContract]
        IEnumerable<Group> GetGroupsCollection(string authToken);

        [OperationContract]
        DeviceDto GetDeviceById(string authToken, long deviceId);

        [OperationContract]
        int GetAssociatedDeviceId(long deviceId); //amit 08072015

        [OperationContract]
        DeviceDto GetDeviceByIdSim(long deviceId);
        [OperationContract]
        DeviceDto GetCameraDeviceByGuid(Guid cameraGuid);

        [OperationContract]
        IEnumerable<DeviceDto> GetDevicesCollectionThinClient(string authToken); //amit 16022017

        [OperationContract]
        IEnumerable<AddressDto> GetSiteAddress(string siteID, string authToken); //amit 03 Aug 15

        [OperationContract]
        IList<DeviceDto> GetDevicesByInterfaceId(int interfaceId);

        [OperationContract]
        IList<UserDto> GetUsers(string authToken, int alertID);

        [OperationContract]
        IList<UserDto> GetUser(string authToken); //amit 14062017 for thinclient

        [OperationContract]
        IEnumerable<string> GetDeviceTypes(string authToken);
       
        [OperationContract]
        IList<NvrDto> GetNvrs(string authToken);       

        [OperationContract]
        NvrDto GetNvrById(string authToken, long nvrId);

        [OperationContract]
        NvrDto GetNvrByInterfaceId(string authToken, long interfaceId);

        [OperationContract]
        Group GetGroupById(string authToken, long groupId);

        [OperationContract]
        IEnumerable<ValuesLookUp> GetValuesLookUp(string authToken);

        [OperationContract]
        IEnumerable<string> GetValuesHistory(string authToken, long deviceId);

        [OperationContract]
        IEnumerable<DeviceVAnalyticsScheduleDTO> GetDevicesScheduleCollection(string authToken, long deviceId);

        [OperationContract]
        IEnumerable<Event> GetNewEvents(string authToken);

        [OperationContract]
        long GetDeviceIdByName(string authToken, string name);

        [OperationContract]
        IEnumerable<tblNokDTO> GetNokPresetCollection(string authToken);

        [OperationContract]
        long GetNokPresetFromNok(string authToken);

       
        [OperationContract]
        IEnumerable<IncidentReportWrapper> GetSelectedDateIncidentReportsByOwner(string authToken, string startCreateDate, string endCreateDate, string ownerUsername);

        [OperationContract]
        bool IsAlertAttached(long IrID, long alertid, string authToken); //amit 03072015

        [OperationContract]
        IEnumerable<tblCameraStatusDto> GetDeviceStatus(string authToken);  //trupti21Aug15 Device status

        [OperationContract]
        long GetUsersite(string authToken);

        //trupti 26 May 15
        [OperationContract]
        IEnumerable<AnalyticsDetailsDto> GetDeviceAnalyticsDetails(string authToken, int siteID);

        [OperationContract]
        long GetAnalyticsDeviceCount(string authToken);

        [OperationContract]
        IEnumerable<IncidentReport> GetContextIRData(string Context);  //trupti10sept15

        [OperationContract]
        IEnumerable<SiteDto> GetContextSiteData(string Context);  //trupti10sept15

        [OperationContract]
        IEnumerable<DeviceDto> GetContextDeviceData(string Context);  //trupti10sept15

        //Amit18sept15        
        [OperationContract]
        IEnumerable<tblCameraBookMarkDto> GetCameraBookMarkCollection(long deviceID, string authToken);        //

        [OperationContract]
        string GetRepositoryConfiguration(string authToken);  //trupti09112015
        
        [OperationContract]  //trupti130516
        IEnumerable<AlarmPanelDTO> GetAlarmPanelInterface(Guid authToken);

        [OperationContract]  //trupti170516
        string GetInterfaceById(string authToken, long InterfaceId);

        [OperationContract]
        IList<AlarmPanelDTO> GetPAInterface();

        [OperationContract]  //AMIT 18112016 Ireo VERSION 1.4.1 need to merger in version 1.5
        IEnumerable<tblcustomeremergencycontactDTO> GetCustomerinfo(string strcid, string authToken);

        [OperationContract]
        IEnumerable<tblNotificationmsgDto> GetUnreadNotifications(string authToken);     //amit 16022017   

        [OperationContract]
        IEnumerable<DeviceDto> GetSearchDevice(string authToken, string SearchTxt); //amit 16022017

        [OperationContract]
        int CheckPasswordValidityRemaining(string authToken); //amit 26092017

        [OperationContract]
        List<SP_ReturnSOPAction_ResultDTO> GetSopAction(string Authtoken, string strseverity, string strcertinity, string strurgency, string alettype, string alertID);//amit 24102017

        [OperationContract]
        IEnumerable<SP_MapSearch_ResultDTO> GetSearchSiteDevice(string authToken, string searchText);

        [OperationContract]
        DeviceDto GetMosaicDeviceCollection(long deviceId);

        [OperationContract]
        IEnumerable<tblPidsDevicelocationInfoDTO> GetPidsDevicelocationInfoCollection(string authToken);

        [OperationContract]
        IEnumerable<tblPidsAlertPresetAssocaitionDTO> GetPidsPTZDeviceCollection(string authToken);

        [OperationContract]
        IEnumerable<tblPrimarySecondaryServerMappingDTO> GetPrimarySecondaryServerMappingCollection(string authToken);

        [OperationContract]
        IEnumerable<tblPrimarySecondaryCamGuidMappingDTO> GetPrimarySecondaryCamGuidMappingCollection(string authToken);

        [OperationContract]
        IEnumerable<SystemBrowserDTO> GetSystemBrowserDetails(string authToken);

        [OperationContract]
        tblWasteBinSensorDataDTO GetWestBinsensorData(string authToken, string DeviceID);

        [OperationContract]
        tblEnvironmentSensorDataDTO GetEnvironmentalsensorData(string authToken, string DeviceID);

        [OperationContract]
        tblVehicleTrackingDataDTO GetTrackingDeviceData(string authToken, string DeviceExternalID);

        [OperationContract]
        IEnumerable<tblAlertContextDTO> GetAlertContextCollection();

        [OperationContract]
        IEnumerable<tblAlertCloseReasonCodeDto> GetCloseReasonCollection();

        [OperationContract]
        IList<string> GetPlaybackRecords(long alertId, long deviceId);//jatin 10032018

        [OperationContract]
        IEnumerable<tblMultiviewTemplateDto> GetPanaromicDeviceTemplateCollection(string Authtoken);//komal 13042018

        [OperationContract]
        IEnumerable<tblPIDSSensorMasterDTO> GetPIDSSensorMasterDTOCollection(string authToken);//amit 20042018

        [OperationContract]
        IEnumerable<tblPIDSSensorPointsDTO> GetPIDSSensorPointsDTOCollection(string authToken);//amit 20042018

        [OperationContract]
        IEnumerable<tblPIDSZoneDTO> GetPIDSZoneCollection(string authToken); //amit 20042018       

        [OperationContract]
        IEnumerable<tblPIDSZoneSectionInfoDTO> GetPIDSZoneSectionInfoCollection(string authToken);//amit 20042018

        [OperationContract]
        IEnumerable<tblfftPIDSAlertInfoDTO> GetFFTPidsAlertInfo(string authToken, int alertID);

        [OperationContract]
        IEnumerable<tblfftcontrollerdeviceassocaitionDTO> GetFFTPidsAssociatedDeviceCollection(string authToken);

        [OperationContract]
        tblVehicleMasterDataDto GetTrackingMasterData(string authToken, string DeviceExternalID);//komal27042018 for Gvts

        [OperationContract]
        IEnumerable<SP_SetfftPIDSDeviceAssociate_ResultDTO> GetFFTPidsAssociatedDevices(int LoadFlag); // jatin 26042018

        [OperationContract]
        AlertplaybackTimeDto GetAlertplaybackTimeData();//komal 29052018

        [OperationContract]
        IEnumerable<tblMultiviewTemplateDto> GetPresentPanoramaConfigurations(); // jatin 11052018

        [OperationContract]
        IEnumerable<SP_GponDeviceStatus_ResultDTO> GetGponDeviceStatus(string authToken, string DeviceID, string OID, string OIDStaus); // jatin 11052018

        [OperationContract]
        IEnumerable<SP_GponDeviceStatus_ResultDTO> GetGponDeviceStatus(string authToken); // jatin 11052018    

        [OperationContract]
        bool DeletePcrScrMappedEntry(string pcrGUID);//harsha 26102018

        [OperationContract]
        List<PcrScrResultDTO> GetPcrScrMappedList();//harsha 26102018

        [OperationContract]
        IEnumerable<AnalyticAlgorithmTypeDto> GetAnalyticAlgorithmTypeCollection(string authToken);
    }
}
