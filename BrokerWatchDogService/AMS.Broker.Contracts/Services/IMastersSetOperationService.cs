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
    public interface IMastersSetOperationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        AlarmPanelTypeMasterDTO SaveAlarmPanelTypeMasterData(string AlarmPanelTypeData, string authToken);

        [OperationContract]
        AnalyticAlgorithmTypeDto SaveAnalyticsAlgoTypeMasterData(string AnalyticsAlgoTypeData, string authToken);

        [OperationContract]
        DeviceTypeDto SaveDeviceTypeMasterData(string DeviceTypeData, string authToken);

        [OperationContract]
        DvrNvrTypeMasterDTO SaveDvrNvrTypeMasterData(string DvrNvrTypeMasterData, string authToken);

        [OperationContract]
        EventCodeDto SaveEventCodeMasterData(string EventCodeData, string authToken);

        [OperationContract]
        EventGroupDto SaveEventGroupMasterData(string EventGroupData, string authToken);

        [OperationContract]
        EventTypeTemplateDto SaveEventTypeTemplateMasterData(string EventTypeTemplateData, string authToken);

        [OperationContract]
        InterfaceTypeDto SaveInterfaceTypeMasterData(string InterfaceTypeData, string authToken);

        [OperationContract]
        MessageTypeDto SaveMessageTypeMasterData(string MessageTypeData, string authToken);

        [OperationContract]
        NvrAlertTypeDto SaveNvrAlertTypeMasterData(string NvrAlertTypeData, string authToken);

        [OperationContract]
        ObjectTypeDto SaveObjectTypeMasterData(string ObjectTypeData, string authToken);

        [OperationContract]
        SiteTypeDto SaveSiteTypeMasterData(string SiteTypeData, string authToken);

        [OperationContract]
        StationTypeDTO SaveStationTypeMasterData(string StationTypeData, string authToken);

        [OperationContract]
        tblAlertCloseReasonCodeDto SaveAlertCloseReasonCodeMasterData(string AlertCloseReasonCodeData, string authToken);

        [OperationContract]
        tblPanelMasterDTO SavePanelMasterData(string PanelMasterData, string authToken);

        [OperationContract]
        tblSOPAlertTypeDTO SaveSOPAlertTypeMasterData(string AlertTypeData, string authToken);

        [OperationContract]
        tblStateMasterDTO SaveStateMasterData(string StateMasterData, string authToken); //harsha

        [OperationContract]
        tblCityMasterDTO SaveCityMasterData(string CityMasterData, string authToken); //harsha

        [OperationContract]
        tblIDSPanelSubsystemMasterDetailsDTO SaveSubsystemData(string SubsystemMasterData, string authToken); //harsha

        [OperationContract]
        tblIDSPanelInfoMasterDetailsDTO SavePanelInfoData(string PanelInfoData, string authToken); //harsha

        [OperationContract]
        tblIDSPanelZonePatternDetailsDTO SaveZonePatternData(string ZonePatternData, string authToken);//harsha

        [OperationContract]
        tblIDSPanelZoneTypeMasterDTO SavePanelZoneTypeData(string ZoneTypeMasterData, string authToken);//komal13052019

        [OperationContract]
        tblSOPIconMasterDTO SaveIconData(tblSOPIconMasterDTO IconMasterData, string authToken);//komal15052019

        [OperationContract]
        bool DeleteIconData(int IconMasterID, string authToken);//komal15052019


        [OperationContract]
        tblPASPreDefinedVoiceMessageDTO SavePASVoiceMessageMasterData(string PASPredefinedMessageData, string authToken);

        [OperationContract]
        tblIDSPanelSubsystemTypeMasterDTO SaveSubsystemTypeData(string SubsystemTypeData, string authToken);

        [OperationContract]
        tblVMDPreDefinedMessageDTO SavePredefinedMessageMasterData(string PredefinedMessageData, string authToken);
    }
}
