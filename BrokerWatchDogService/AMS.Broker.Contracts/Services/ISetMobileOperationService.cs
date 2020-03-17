using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISetMobileOperationService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool AcknowledgeAlertsMobile(string authToken, string alerts);

        [OperationContract]
        long SetAlertOwner(string authToken, int alertID);

        [OperationContract]
        void SendMobileNotificationNative(string AlertID);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaPic(Stream strData);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaAudio(Stream strData);

        [OperationContract] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaVideo(Stream strData);

        [OperationContract]
        bool UpdateMobileAlert(double lattitude, double longitude, string Address, string AuthToken, string alertId, string retPath, string retVoicenotePath, string retVideoPath);

        [OperationContract]
        bool CancelAlertsMobile(string alerts);

        [OperationContract]
        int ChangePasswordNew(string username, string oldPassword, string newPassword); //amit 27092017// jatin 06012017

        [OperationContract]
        bool RemoveFcmToken(string FCMToken);

        [OperationContract]
        bool DeleteMedia(string FileName);

        [OperationContract(Name = "AddMobileDocToIR")]
        string AddMobileDocToIR(Stream data);

        [OperationContract(Name = "addMobileResource")] //amit 10/10/2017 //saurabh 13112017
        string addMobileResource(long irID, string AuthToken, string Owner, string CreationDate, string attachdate, byte[] data, double lattitude, double longitude, string Address, int EvidenceType, int AlertID);

        [OperationContract]
        bool CreateMobileIncidentReport(string AuthToken, string AlertId);

        [OperationContract(Name = "MobAddAlertToIncidentReport")]
        string MobAddAlertToIncidentReport(double lattitude, double longitude, string Address, string authToken, long alertId, long incidentReportId, DateTime _attachedDateTime);


        [OperationContract]
        string GetCamURL(long DeviceId, string type, string StartTime, string StopTime);

        [OperationContract(Name = "AddMobileDocumentToIR")]
        string AddMobileDocumentToIR(long irID, string AuthToken, string Owner, string CreationDate, string attachdate, string data, string strFilename, double lattitude, double longitude, string Address, int AlertID);

        //[OperationContract(Name = "AddIrEvidencesTypewiseMobile")]
        //void AddIrEvidencesTypewiseMobile(double lattitude, double longitude, string Address, string AuthToken, long incidentReportId, int RefAlertID, int RefIrId, int AttachCameraID, Guid resourceId, DateTime appendDate, int EvidenceType);

        [OperationContract]
        bool AddMobileDevice(string DeviceName, string MobileNumber);
    }
}
