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
    public interface ISetMobileDataService
    {
        [OperationContract(Name = "UpdloadMediaPic")] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaPic(Stream strData);

        [OperationContract(Name = "UpdloadMediaAudio")] //amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaAudio(Stream strData);

        [OperationContract(Name = "UpdloadMediaVideo")]//amit 10/10/2017 //saurabh 13112017
        string UpdloadMediaVideo(Stream strData);

        [OperationContract]
        string GetCamURL(long DeviceId, string type, string StartTime, string StopTime);

        [OperationContract]
        bool CreateMobileIncidentReport(string AuthToken, string AlertId);

        [OperationContract(Name = "addMobileResource")] //amit 10/10/2017 //saurabh 13112017
        string addMobileResource(long irID, string AuthToken, string Owner, string CreationDate, string attachdate, byte[] data);

        [OperationContract(Name = "AddMobileDocToIR")]
        string AddMobileDocToIR(Stream data);

        [OperationContract(Name = "MobAddAlertToIncidentReport")]
        string MobAddAlertToIncidentReport(string authToken, long alertId, long incidentReportId, DateTime _attachedDateTime);

        [OperationContract(Name = "AddMobileDocumentToIR")]
        string AddMobileDocumentToIR(long irID, string AuthToken, string Owner, string CreationDate, string attachdate, string data, string strFilename);
       

    }
}