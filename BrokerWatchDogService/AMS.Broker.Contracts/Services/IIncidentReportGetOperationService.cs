using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIncidentReportGetOperationService
    {
        

        [OperationContract(Name = "GetIncidentReport")]
        IncidentReportWrapper GetIncidentReport(Contracts.DTO.User user, long incidentReportId);

        [OperationContract(Name = "GetIncidentReportByCreateDate")]
        List<IncidentReportWrapper> GetIncidentReportsByCreateDate(Contracts.DTO.User user, DateTime startCreateDate, DateTime endCreateDate);

        [OperationContract(Name = "GetIncidentReportByStatus")]
        List<IncidentReportWrapper> GetIncidentReportsByStatus(Contracts.DTO.User user, DateTime startCreateDate, DateTime endCreateDate, string status);

        [OperationContract(Name = "GetIncidentReportByOwner")]
        List<IncidentReportWrapper> GetIncidentReportsByOwner(Contracts.DTO.User user, DateTime startCreateDate, DateTime endCreateDate, string ownerUsername);
                
        [OperationContract(Name = "GetIncidentReportByLastUpdatedBy")]
        List<IncidentReportWrapper> GetIncidentReportsByLastUpdatedBy(Contracts.DTO.User user, DateTime startCreateDate, DateTime endCreateDate, string lastUpdatedBy);

       
        [OperationContract(Name = "GetResource")]
        ResourceData GetResource(ResourceData data);

        [OperationContract(Name = "GetCameraPlayDateTime")]
        string GetCameraPlayDateTime(long cameraId,long reportId);

        [OperationContract(Name = "GetVideoResource")]
        ResourceData GetVideoResource(ResourceData data);          

        
        [OperationContract(Name = "GetIncidentReportByIDWeb")]
        List<IncidentReportWrapper> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);


        [OperationContract(Name = "GetIncidentReportById")]   //trupti14Sept15
        IncidentReportWrapper GetIncidentReportById(long IncidentReportId);

        [OperationContract(Name = "GetIncidentReportAlertDetails")]   //trupti 23 Feb 16
        IncidentReportAlertDTO GetIncidentReportAlertDetails(long IncidentReportId, long AlertId);     


    }
}
