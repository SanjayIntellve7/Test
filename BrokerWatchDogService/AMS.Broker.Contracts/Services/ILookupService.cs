using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ILookupService
    {
        [OperationContract]
        IEnumerable<AccountTypeDto> GetAccountTypes();

        [OperationContract]
        IEnumerable<ServicePackageDto> GetServicePackages();

        [OperationContract]
        IEnumerable<DeliveryMethodDto> GetDeliveryMethods();

        [OperationContract]
        IEnumerable<ContactTypeDto> GetContactTypes();

        [OperationContract]
        IEnumerable<GenderDto> GetGenders();

        [OperationContract]
        IEnumerable<TimeZoneDto> GetTimeZones();

        [OperationContract]
        IEnumerable<InterfaceTypeDto> GetInterfaceTypes(string authToken);      
        
        [OperationContract]
        IEnumerable<DvrNvrTypeMasterDTO> GetDvrNvrTypes();

        [OperationContract]
        IEnumerable<EventCodeDto> GetEventCodes();

        [OperationContract]
        IEnumerable<EventTypeTemplateDto> GetEventTypes();

        [OperationContract]
        IEnumerable<EventGroupDto> GetEventGroups();

        [OperationContract]
        IEnumerable<EventQualifierDto> GetEventQualifiers();

        [OperationContract]
        IEnumerable<CertaintyDto> GetCertainties();

        [OperationContract]
        IEnumerable<MessageTypeDto> GetMessageTypes();

        [OperationContract]
        IEnumerable<ResponseTypeDto> GetResponseTypes();

        [OperationContract]
        IEnumerable<SeverityDto> GetSeverities();

        [OperationContract]
        IEnumerable<StatusDto> GetStatuses();

        [OperationContract]
        IEnumerable<UrgencyDto> GetUrgencies();

        [OperationContract]
        IEnumerable<CategoryDto> GetCategories();

        [OperationContract]
        IEnumerable<DeviceTypeDto> GetDeviceTypes();

        [OperationContract]
        IEnumerable<AnalyticAlgorithmTypeDto> GetAnalyticAlgorithmTypes(string authToken);

        [OperationContract]
        IEnumerable<ScopeDto> GetAlertScopes();

        [OperationContract]
        IEnumerable<ContactMethodDto> GetContactMethods();

        [OperationContract]
        IEnumerable<PaymentMethodDto> GetPaymentMethods();

        [OperationContract]
        IEnumerable<NvrAlertTypeDto> GetNvrAlertTypes();

        [OperationContract]
        IEnumerable<EventTypeTemplateDto> GetAnalyticsEventTypes();

        [OperationContract]
        IEnumerable<AlarmPanelTypeMasterDTO> GetAlarmInterfaceSubType(); //trupti09july15

        [OperationContract]
        IEnumerable<DvrNvrTypeMasterDTO> GetNvrInterfaceSubType(); //trupti02122015      

        [OperationContract]
        IEnumerable<tblSOPTypeDTO> GetSOPTypes(string authToken);

        [OperationContract]
        IEnumerable<tblSOPTriggerActionTypeDTO> GetSOPTriggerActionTypes(string authToken, string sopTypeID);

        [OperationContract]
        IEnumerable<tblSOPAlertTypeDTO> GetSOPAlertTypes(string authToken);

        [OperationContract]
        IEnumerable<tblSOPInputTypeDTO> GetSOPInputTypes(string authToken);


        [OperationContract]
        IEnumerable<tblSOPMasterDTO> GetSOPMasterData(string authToken, string sopmasterID);

        [OperationContract]
        IEnumerable<tblSettingTypeMasterDTO> GetSettingTypes(string authToken);


        [OperationContract]
        IEnumerable<tblSMTPConfigurationDTO> GetSMTPConfiguration(string authToken);

        [OperationContract]
        IEnumerable<tblSMSConfigurationDTO> GetSMSConfiguration(string authToken);

        [OperationContract]
        IEnumerable<tblStreamTypeMasterDTO> GetCameraStreamMaster(string authToken);
    }
}
