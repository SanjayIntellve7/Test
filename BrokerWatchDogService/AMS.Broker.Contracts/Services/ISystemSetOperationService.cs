using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISystemSetOperationService
    {
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        InterfaceDto AddInterface(InterfaceDto interfaceToAdd, int accountId, int siteId, string authToken);

        [OperationContract]
        InterfaceDto UpdateInterface(InterfaceDto interfaceToUpdate, string authToken);

        [OperationContract]
        bool Delete(int interfaceId, string authToken);

        [OperationContract]
        EventTemplateDto SaveEventTemplate(EventTemplateDto eventTemplateDto, string authToken);

        [OperationContract]
        bool DeleteEventTemplate(int eventTemplateId, string authToken);

        //trupti 20 nov 14
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        DeviceDto AddNvrToNvrInterface(DeviceDto deviceDto, NvrCameraDto nvrCameraDto, int inrefaceId, string authToken);
        //
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        DeviceDto AddDeviceToInterface(DeviceDto deviceDto, int inrefaceId, string authToken);

        [OperationContract]
        DeviceDto UpdateDevice(DeviceDto deviceDto, int inrefaceId, string authToken);

        [OperationContract]
        bool DeleteDevice(long deviceId, string authToken);

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        AnalyticsEventTemplateDto SaveAnalyticsEventTemplate(AnalyticsEventTemplateDto analyticsEventTemplateDto, string authToken);

        [OperationContract]
        bool DeleteAnalyticsEventTemplate(int analyticsEventTemplateId, string authToken);

        [OperationContract]
        void StartVideoAnalytics(int cameraId);

        [OperationContract]
        void StopVideoAnalytics(int cameraId);

        [OperationContract]
        tblPTZPresetAssociationDto UpdatePTZPresetList(string PTZPresetAssociationlst, string authToken);  //trupti11122015

        [OperationContract]
        tblDvrChanelMasterDto AddInterfaceChanel(tblDvrChanelMasterDto ChanelToAdd, string authToken); //trupti160116

        [OperationContract]
        tblSOPMasterDTO SaveSOPData(tblSOPMasterDTO tblSOPMasterToAdd, string authToken);

        [OperationContract]
        tblSOPMasterDTO UpdateSOPData(tblSOPMasterDTO tblSOPMasterToAdd, string authToken);

        [OperationContract]
        bool DeleteSOPData(int sopMasterID, string authToken);

        //amit 12102017
        [OperationContract]
        bool DeleteSmsConfiguration(int smsconfigId, string authToken);

        [OperationContract]
        bool DeleteSmtpConfiguration(int smtpconfigId, string authToken);

        [OperationContract]
        tblSMSConfigurationDTO SaveSmsConfiguration(tblSMSConfigurationDTO tblSmsConfigdto, string authToken);

        [OperationContract]
        tblSMSConfigurationDTO UpdateSmsConfiguration(tblSMSConfigurationDTO tblSmsConfigdto, string authToken);

        [OperationContract]
        tblSMTPConfigurationDTO SaveSMTPConfiguration(tblSMTPConfigurationDTO tblSmtpConfigdto, string authToken);

        [OperationContract]
        tblSMTPConfigurationDTO UpdateSMTPConfiguration(tblSMTPConfigurationDTO tblSmtpConfigdto, string authToken);

        [OperationContract]
        IEnumerable<ObjectsAssociationDto> SaveAssociatedDeviceList(List<ObjectsAssociationDto> AssociatedDevice);

        [OperationContract]
        bool SharePersepective(string perspectiveID, string displayID, string AuthToken);

         [OperationContract]
        bool UnsharePersepective(string perspectiveID, string displayID, string AuthToken);

         [OperationContract]
         ImportDeviceInsertStatus SaveImportDevicesList(List<DeviceDto> AllDeviceList, string AuthToken);//komal27112019

         [OperationContract]
         ImportInterfaceInsertStatus SaveImportInterfaceList(List<InterfaceDto> AllInterfaceList, string AuthToken);//komal27112019

         [OperationContract]
         bool MultipleAnalyticsCrud(List<tblAnalyticsInfoDto> AnalyticsInfo, string authToken); //Tejasvini 14012019

    }
}
