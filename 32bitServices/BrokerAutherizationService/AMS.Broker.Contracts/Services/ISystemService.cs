using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISystemService
    {
        [OperationContract]
        List<InterfaceTypeDto> GetInterfaceTypes();

        [OperationContract]
        List<DvrNvrTypeMasterDTO> GetDvrNvrTypes();

        [OperationContract]
        List<InterfaceDto> GetInterfacesForAccount(int accountId, string username);

        [OperationContract]
        List<InterfaceDto> GetInterfacesForSite(int siteId);

        [OperationContract]
        InterfaceDto GetInterface(int interfaceId);        

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        InterfaceDto AddInterface(InterfaceDto interfaceToAdd, int accountId, int siteId);

        [OperationContract]
        InterfaceDto UpdateInterface(InterfaceDto interfaceToUpdate);

        [OperationContract]
        bool Delete(int interfaceId);

        [OperationContract]
        bool HasInterfaces(int accountId);

        [OperationContract]
        EventTemplateDto GetEventTemplate(int eventTemplateId);

        [OperationContract]
        EventTemplateDto GetEventTemplateByCodeAndQualifier(int eventTypeTemplateId, int eventCodeId, int eventQualifierId);

        [OperationContract]
        EventTemplateDto SaveEventTemplate(EventTemplateDto eventTemplateDto);

        [OperationContract]
        bool DeleteEventTemplate(int eventTemplateId);

        //trupti 20 nov 14
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        DeviceDto AddNvrToNvrInterface(DeviceDto deviceDto, NvrCameraDto nvrCameraDto, int inrefaceId);
        //

        [OperationContract]
        IList<DeviceDto> GetInterfaceDevices(int interfaceId);

        [OperationContract]
        IList<DeviceDto> GetSiteDevices(int siteId);

        [OperationContract]
        IList<DeviceDto> GetSiteHierarchyDevices(int siteId);

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        DeviceDto AddDeviceToInterface(DeviceDto deviceDto, int inrefaceId);

        [OperationContract]
        DeviceDto UpdateDevice(DeviceDto deviceDto, int inrefaceId);

        [OperationContract]
        bool DeleteDevice(long deviceId);

        [OperationContract]
        DeviceDto GetDeviceById(int deviceId);

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        AnalyticsEventTemplateDto SaveAnalyticsEventTemplate(AnalyticsEventTemplateDto analyticsEventTemplateDto);

        [OperationContract]
        AnalyticsEventTemplateDto GetAnalyticsEventTemplate(int analyticsEventTemplateId);

        [OperationContract]
        AnalyticsEventTemplateDto GetAnalyticsEventTemplateByName(string analyticsEventTemplateId);

        [OperationContract]
        bool DeleteAnalyticsEventTemplate(int analyticsEventTemplateId);

        [OperationContract]
        IList<AnalyticsEventTemplateDto> GetAnalyticsEventTemplates();

        [OperationContract]
        IList<AnalyticsEventTemplateDto> GetAnalyticsEventTemplatesByAlgorithmId(int algorithmTypeId);

        [OperationContract]
        void StartVideoAnalytics(int cameraId);

        [OperationContract]
        void StopVideoAnalytics(int cameraId);

        [OperationContract]
        AlarmPanelTypeMasterDTO GetAlarmMasterDto(long MasterTypeId); //trupti31Aug15


        [OperationContract]
        IList<DeviceDto> GetPtzDeviceList();  //trupti11122015

        [OperationContract]
        IList<tblPTZPresetAssociationDto> GetPTZPresetList(long deviceID);  //trupti11122015

        [OperationContract]
        tblPTZPresetAssociationDto UpdatePTZPresetList(string PTZPresetAssociationlst);  //trupti11122015

        [OperationContract]
        tblDvrChanelMasterDto AddInterfaceChanel(tblDvrChanelMasterDto ChanelToAdd); //trupti160116

        [OperationContract]
        tblDvrChanelMasterDto GetInterfaceChanel(int interfaceId);//trupti160116

        [OperationContract]
        List<int> GetUsedChanelNos(int interfaceId);//trupti160116      

    }
}
