using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISystemGetOperationService
    {
        [OperationContract]
        List<InterfaceTypeDto> GetInterfaceTypes(string authToken);

        [OperationContract]
        IEnumerable<tblSOPTypeDTO> GetSOPTypes(string authToken);

        [OperationContract]
        List<DvrNvrTypeMasterDTO> GetDvrNvrTypes(string authToken);

        [OperationContract]
        List<InterfaceDto> GetInterfacesForAccount(int accountId, string username, string authToken);

        [OperationContract]
        List<InterfaceDto> GetInterfacesForSite(int siteId, string authToken);

        [OperationContract]
        InterfaceDto GetInterface(int interfaceId, string authToken); 
       
        [OperationContract]
        bool HasInterfaces(int accountId, string authToken);

        [OperationContract]
        EventTemplateDto GetEventTemplate(int eventTemplateId, string authToken);

        [OperationContract]
        EventTemplateDto GetEventTemplateByCodeAndQualifier(int eventTypeTemplateId, int eventCodeId, int eventQualifierId, string authToken);
               
        [OperationContract]
        IList<DeviceDto> GetInterfaceDevices(int interfaceId, string authToken);

        [OperationContract]
        IList<DeviceDto> GetSiteDevices(int siteId, string authToken);

        [OperationContract]
        IList<DeviceDto> GetSiteHierarchyDevices(int siteId, string authToken);
                
        [OperationContract]
        DeviceDto GetDeviceById(int deviceId, string authToken);
       
        [OperationContract]
        AnalyticsEventTemplateDto GetAnalyticsEventTemplate(int analyticsEventTemplateId, string authToken);

        [OperationContract]
        AnalyticsEventTemplateDto GetAnalyticsEventTemplateByName(string analyticsEventTemplateId);       

        [OperationContract]
        IList<AnalyticsEventTemplateDto> GetAnalyticsEventTemplates(string authToken);

        [OperationContract]
        IList<AnalyticsEventTemplateDto> GetAnalyticsEventTemplatesByAlgorithmId(int algorithmTypeId, string authToken);
                
        [OperationContract]
        AlarmPanelTypeMasterDTO GetAlarmMasterDto(long MasterTypeId, string authToken); //trupti31Aug15

        [OperationContract]
        IList<DeviceDto> GetPtzDeviceList();  //trupti11122015

        [OperationContract]
        IList<tblPTZPresetAssociationDto> GetPTZPresetList(long deviceID, string authToken);  //trupti11122015
                
        [OperationContract]
        tblDvrChanelMasterDto GetInterfaceChanel(int interfaceId, string authToken);//trupti160116

        [OperationContract]
        List<int> GetUsedChanelNos(int interfaceId, string authToken);//trupti160116      

        [OperationContract]
        IList<DeviceDto> GetAllDevices(string authToken); //for touch config user privilage list

        [OperationContract]
        IList<DeviceDto> GetUserDevices(string userID); //for touch config user privilage list

        [OperationContract]
        IEnumerable<tblSettingTypeMasterDTO> GetSettingTypes(string authToken);

        [OperationContract]
        IEnumerable<InternalContactDetailsDTO> GetInternalContactDetails(string authToken, int interfaceId);

        [OperationContract]
        IEnumerable<ExternalContactDetailsDTO> GetExternalContactDetails(string authToken, int interfaceId);
    }
}
