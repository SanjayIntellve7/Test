using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IControllerSetOperationService
    {
        [OperationContract]
        Group UpdateGroup(string authToken, string serializedGroup);

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
        bool CloseAlertsAll(long deviceID, Guid authToken, int CloseReasonID, int CloseFlag, long AlertId, string StrComment);

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
        bool UpdateNvr(string authToken, string nvr);

        [OperationContract]
        bool DeleteNvr(string authToken, long nvrId);
       
        [OperationContract]
        long SetPresetOnAlert(string authToken, string name);

        [OperationContract]
        bool InsertCameraBookMark(long deviceID, string bookmarkdate, string remarks, string authToken);

        //amit 13 Jan 16
        [OperationContract(Name = "ActivateDashBoardStation")]
        Station ActivateDashBoardStation(String authToken, String identifier);

        //amit 13 Jan 16
        [OperationContract(Name = "RegisterDashBoardStation")]
        Boolean RegisterDashBoardStation(String authToken, String identifier, String type, String description, String metadata, String longitued = null, String latitude = null);

        //amit 13 Jan 16
        [OperationContract(Name = "DeactivateDashBoardStation")]
        void DeactivateDashBoardStation(String authToken, String identifier);    

        [OperationContract]
        bool CloseThinClientNotification(string NotificationId); //amit 16022017    

        [OperationContract]
        void AddDeviceOperationAudit(string entityID, string OperationTypeName, string OperationName, string authToken, string stationIdentifier, string reserve1, string reserve2, string reserve3);

        [OperationContract]
        bool XtendCall(int AlertID, long Mobno, int Status, string Msg, string Campid, string Recid, string DateTime, string Authtoken);

        [OperationContract]
        int ChangePasswordNew(string username, string oldPassword, string newPassword); //amit 27092017// jatin 06012017

        [OperationContract]
        bool SetPidsAssociatedDeviceConfig(string content); // jatin 27042018

        [OperationContract(Name = "DeleteFFTAssociatedDeviceConfig")]
        bool DeleteFFTAssociatedDeviceConfig(int ControllerID, int ZoneID, int DeviceID, int PresetNo);

        [OperationContract]
        bool RegisterAnprVehicle(string authToken, string content);

        [OperationContract]
        bool SaveTimeMaskingConfiguration(string content);//jatin 30052018

        [OperationContract]
        bool SavePanoramicConfiguration(string content);

        [OperationContract]
        bool StartInaugration(string Message, int AnimationTime);

        [OperationContract]
        bool SendSMSFromTC(string authToken, string Message, string MobNumber);        

        [OperationContract]
        bool MapPcrScrNvrCamera(List<PcrScrResultDTO> _PcrScrResultDTOList);

        [OperationContract]
        bool UpdateVehicleNumber(string authToken, string vehNumber, string AlertID, string Type);

        [OperationContract]
        bool SavePanelSimDetails(string content);

        [OperationContract]
        bool SetPanelMode(int DeviceID, string  Mode);

        [OperationContract]
        bool UpdateMiracysDeviceStatus(string DeviceName, string StrGuid, string Status); //amit 22102019

        [OperationContract]
        bool ShowTwoWayCommunicationStatus(long alertid, int siteid, int interfaceid, bool Communicationstatus, string _time, string authToken); //manish221019

        [OperationContract]
        bool RegisterVaranasiAnprVehicle(string authToken, string content);

        [OperationContract]
        bool DeleteRegisterAnprVehicle(string authToken, string content);

        [OperationContract]
        int OpenGallagherAcsDoor(string authToken, string DoorID);

        [OperationContract]
        string GetGalagherDoorStatus(string authToken, string DoorID);

        [OperationContract]
        bool SetLEDwiseControl(string LEDlist, string authtoken);

        [OperationContract]
        bool SetWardwiseControl(string Wardlist, string authtoken);
    }
}
