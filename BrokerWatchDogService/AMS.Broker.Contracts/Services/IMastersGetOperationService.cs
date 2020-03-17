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
    public interface IMastersGetOperationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        IEnumerable<tblSystemMasterInfoDTO> GetAllMasterInfo(string authToken);

        [OperationContract]
        IEnumerable<AlarmPanelTypeMasterDTO> GetAllAlarmPanelTypeMaster(string authToken);

        [OperationContract]
        IEnumerable<AnalyticAlgorithmTypeDto> GetAllAnalyticAlgorithmType(string authToken);

        [OperationContract]
        IEnumerable<DeviceTypeDto> GetAllDeviceType(string authToken);

        [OperationContract]
        IEnumerable<DvrNvrTypeMasterDTO> GetAllDvrNvrTypeMaster(string authToken);

        [OperationContract]
        IEnumerable<EventCodeDto> GetAllEventCode(string authToken);

        [OperationContract]
        IEnumerable<EventGroupDto> GetAllEventGroup(string authToken);

        [OperationContract]
        IEnumerable<EventTypeTemplateDto> GetAllEventTypeTemplate(string authToken);

        [OperationContract]
        IEnumerable<InterfaceTypeDto> GetAllInterfaceType(string authToken);

        [OperationContract]
        IEnumerable<MessageTypeDto> GetAllMessageType(string authToken);

        [OperationContract]
        IEnumerable<NvrAlertTypeDto> GetAllNvrAlertType(string authToken);

        [OperationContract]
        IEnumerable<ObjectTypeDto> GetAllObjectType(string authToken);

        [OperationContract]
        IEnumerable<SiteTypeDto> GetAllSiteType(string authToken);

        [OperationContract]
        IEnumerable<StationTypeDTO> GetAllStationType(string authToken);

        [OperationContract]
        IEnumerable<tblAlertCloseReasonCodeDto> GetAllAlertCloseReasonCode(string authToken);

        [OperationContract]
        IEnumerable<tblPanelMasterDTO> GetAllPanelMaster(string authToken);

        [OperationContract]
        IEnumerable<tblSOPAlertTypeDTO> GetAllSOPAlertType(string authToken);

        [OperationContract]
        IEnumerable<tblStateMasterDTO> GetAllStateList(string authToken);

        [OperationContract]
        IEnumerable<tblCityMasterDTO> GetAllCityList(string authToken);

        [OperationContract]
        IEnumerable<tblPanelMasterDTO> GetAllPanelTypeList(string authToken);

        [OperationContract]
        IEnumerable<tblIDSPanelSubsystemTypeMasterDTO> GetAllSubsystemType(string authToken);

        [OperationContract]
        IEnumerable<tblIDSPanelSubsystemMasterDetailsDTO> GetAllSubsystemMaster(string authToken);

        [OperationContract]
        IEnumerable<SiteDto> GetSiteDetails(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDeviceDetails(string authToken);

        [OperationContract]
        IEnumerable<tblIDSPanelInfoMasterDetailsDTO> GetAllPanelInfo(string authToken);

        [OperationContract]
        IEnumerable<tblIDSPanelZonePatternDetailsDTO> GetAllZonePatternDetails(string authToken); //harsha 100519

        [OperationContract]
        IEnumerable<tblIDSPanelZoneTypeMasterDTO> GetAllZoneTypeMaster(string authToken);//komal13052019

        [OperationContract]
        IEnumerable<tblSOPIconMasterDTO> GetAllIconMaster(string authToken);//komal15052019

        [OperationContract]
        IEnumerable<tblPASPreDefinedVoiceMessageDTO> GetAllPASVoiceMessageInfo(string authToken);

        [OperationContract]
        IEnumerable<tblVMDPreDefinedMessageDTO> GetAllVMDPredefinedMessageMaster(string authToken);
    }
}

