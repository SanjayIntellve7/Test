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
    public interface IIDSPanelOperationService
    {

        #region Texecom
        [OperationContract]
        tblIDSPanelInfoDTO LoginIntoPanel(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ArmPanel(string content);

        [OperationContract]
        tblIDSPanelInfoDTO DisarmPanel(string content);

        [OperationContract]
        tblIDSPanelInfoDTO Bypass(string content);

        [OperationContract]
        tblIDSPanelInfoDTO UnBypass(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ClearAlarmTex(string content);  // jatin 20032019 TUC-2814

        [OperationContract]
        tblIDSPanelInfoDTO HooterOnTex(string content);

        [OperationContract]
        tblIDSPanelInfoDTO HooterOffTex(string content);

        [OperationContract]
        tblIDSPanelInfoDTO RelayOnTex(string content);

        [OperationContract]
        tblIDSPanelInfoDTO RelayOffTex(string content);

        [OperationContract]
        bool DisconnectPanelTex(string content);

        #endregion

        [OperationContract]
        void AddIDSPanelOperationAudit(string entityID, string OperationTypeName, string OperationName, string authToken, string stationIdentifier, string reserve1, string reserve2, string reserve3, string userInput, string convertedUserInput, string output); // jatin 16012018 changes

        [OperationContract]
        bool CheckPanelConnection(string IP, int port); // jatin 24012019 defects

        #region Hikvision
        [OperationContract]
        tblIDSPanelInfoDTO LoginIntoPanelHik(string IpAddress, string Port, string Username, string Password);

        [OperationContract]
        tblIDSPanelInfoDTO NormalArmHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO QuickArmHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO StayArmHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO DisArmHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ActivateHooterHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO DeactivateHooterHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ByPassHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO UnByPassHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ClearAlarmHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO GetPartitionStatusHik(string content);

        [OperationContract]
        tblIDSPanelInfoDTO LogoutFromPanelHik(string content);
        #endregion 


        #region SmartI

        [OperationContract]
        tblIDSPanelInfoDTO ConnectToSmartIPanel(string IpAddress, string Port);

        [OperationContract]
        tblIDSPanelInfoDTO SIHooterActivation(string content);

        [OperationContract]
        tblIDSPanelInfoDTO SIHooterDeactivation(string content);

        [OperationContract]
        tblIDSPanelInfoDTO FullSystemArmSI(string content);

        [OperationContract]
        tblIDSPanelInfoDTO FullSystemDisarmSI(string content);

        [OperationContract]
        tblIDSPanelInfoDTO InstantArmSI(string content);

        [OperationContract]
        tblIDSPanelInfoDTO InstantDisarmSI(string content);

        [OperationContract]
        bool TestModeStatusSI(string content); // true - ON false - OFF

        [OperationContract]
        tblIDSPanelInfoDTO TestModeONSI(string content);

        [OperationContract]
        tblIDSPanelInfoDTO TestModeOFFSI(string content);


        [OperationContract]
        tblIDSPanelInfoDTO ZoneEnableSI(string content);

        [OperationContract]
        tblIDSPanelInfoDTO ZoneDisableSI(string content);

        #endregion

        #region Securico

        [OperationContract]
        tblIDSPanelInfoDTO RelayActivationSec(string content);

        [OperationContract]
        tblIDSPanelInfoDTO RelayDeactivationSec(string content);

        [OperationContract]
        tblIDSPanelInfoDTO FullSystemArmSec(string content);

        [OperationContract]
        tblIDSPanelInfoDTO FullSystemDisarmSec(string content);

        [OperationContract]
        tblIDSPanelInfoDTO PartitionArmSec(string content);

        [OperationContract]
        tblIDSPanelInfoDTO PartitionDisarmSec(string content);

        #endregion
    }
}
