using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IControllerService
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
        IList<ResourceData> GetAttachResourceCollection();
     
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
        IEnumerable<AddressDto> GetSiteAddress(string siteID); //amit 03 Aug 15

        [OperationContract]
        IList<DeviceDto> GetDevicesByInterfaceId(int interfaceId);

        [OperationContract]
        Group UpdateGroup(string authToken, string serializedGroup);

        [OperationContract]
        IEnumerable<string> GetDeviceTypes(string authToken);

        [OperationContract]
        bool CreateDeviceType(string authToken, string newType);

        [OperationContract]
        bool UpdateDeviceType(string authToken, string currentType, string newType);

        [OperationContract]
        bool UpdateDevice(Guid authToken, string device);

        [OperationContract]
        bool UpdateDeviceVAnalyticsSchedule(Guid authToken, long deviceID);

        [OperationContract]
        bool EnableDeviceVAnalyticsSchedule(Guid authToken, long deviceID);

        [OperationContract]
        bool CloseAlertsAll(long deviceID, Guid authToken);

        [OperationContract]
        IList<UserDto> GetUsers(string authToken);


        [OperationContract]
        bool DeleteDeviceType(string authToken, string typeToDelete);

        [OperationContract]
        bool SubmitDevice(string authToken, string content);

        [OperationContract]
        bool SubmitDeviceSchedule(string authToken, string content);

        [OperationContract]
        bool DeleteDevice(string authToken, long devId);

        [OperationContract]
        bool AddNvr(string authToken, string Nvr);

        [OperationContract]
        NvrDto AddNvrByDto(NvrDto nvrDto);

        [OperationContract]
        NvrDto UpdateNvrByDto(NvrDto nvrDto);

        [OperationContract]
        IList<NvrDto> GetNvrs(string authToken);

        [OperationContract]
        bool UpdateNvr(string authToken, string nvr);

        [OperationContract]
        bool DeleteNvr(string authToken, long nvrId);

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
        long SetPresetOnAlert(string authToken, string name);

        [OperationContract]
        IEnumerable<IncidentReportWrapper> GetSelectedDateIncidentReportsByOwner(string authToken, string startCreateDate, string endCreateDate, string ownerUsername);

        [OperationContract]
        bool IsAlertAttached(long IrID, long alertid); //amit 03072015

        [OperationContract]
        IEnumerable<tblCameraStatusDto> GetDeviceStatus(string authToken);  //trupti21Aug15 Device status

        [OperationContract]
        long GetUsersite(string userName);

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
        bool InsertCameraBookMark(long deviceID, string bookmarkdate, string remarks);
        [OperationContract]
        IEnumerable<tblCameraBookMarkDto> GetCameraBookMarkCollection(long deviceID);
        //

        [OperationContract]
        string GetRepositoryConfiguration(string authToken);  //trupti09112015

        //amit 13 Jan 16
        [OperationContract(Name = "ActivateDashBoardStation")]
        Station ActivateDashBoardStation(String authToken, String identifier);

        //amit 13 Jan 16
        [OperationContract(Name = "RegisterDashBoardStation")]
        Boolean RegisterDashBoardStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);

        //amit 13 Jan 16
        [OperationContract(Name = "DeactivateDashBoardStation")]
        void DeactivateDashBoardStation(String authToken, String identifier);

        [OperationContract]  //trupti130516
        IEnumerable<AlarmPanelDTO> GetAlarmPanelInterface(Guid authToken);

        [OperationContract]  //trupti170516
        string GetInterfaceById(string authToken, long InterfaceId);

       

    }
}
