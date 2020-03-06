using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIncidentReportService
    {
        [OperationContract(Name = "CreateIncidentReport")]
        IncidentReportWrapper CreateIncidentReport(Contracts.DTO.User user, Alert alert);

        [OperationContract(Name = "AddCameraToIncidentReport")]
        IncidentReportWrapper AddCameraToIncidentReport(User user, DeviceDto camera, long incidentReportId, string strDateTime);

        [OperationContract(Name = "RemoveCameraFromIncidentReport")]
        IncidentReportWrapper RemoveCameraFromIncidentReport(User user, long cameraToRemoveId, long incidentReportId);

        [OperationContract(Name = "AddIncidentReportToIncidentReport")]
        IncidentReportWrapper AddIncidentReportToIncidentReport(User user, long incidentReportToAdd, long incidentReportId, DateTime _attachedDateTime);

        [OperationContract(Name = "RemoveIncidentReportFromIncidentReport")]
        IncidentReportWrapper RemoveIncidentReportFromIncidentReport(User user, long incidentReportToRemoveId,
                                                                   long incidentReportId);

       // [OperationContract(Name = "AddAlertToIncidentReport")]
      //  IncidentReportWrapper AddAlertToIncidentReport(Contracts.DTO.User user, Alert alert, long incidentReportId);
        [OperationContract(Name = "AddAlertToIncidentReport")]
        IncidentReportWrapper AddAlertToIncidentReport(Contracts.DTO.User user, Alert alert, long incidentReportId, DateTime _attachedDateTime);

        [OperationContract(Name = "RemoveAlertFromIncidentReport")]
        IncidentReportWrapper RemoveAlertFromIncidentReport(Contracts.DTO.User user, Alert alert, long incidentReportId);

        [OperationContract(Name = "AddResourceToIncidentReport")]
        IncidentReportWrapper AddResourceToIncidentReport(User user, long incidentReportId, Guid resourceId, DateTime appendDate);

        [OperationContract(Name = "RemoveResourceFromIncidentReport")]
        IncidentReportWrapper RemoveResourceFromIncidentReport(User user, long incidentReportId, Guid resourceId);

        [OperationContract(Name = "UpdateIncidentReportStatus")]
        bool UpdateIncidentReport(Contracts.DTO.User user, long incidentReportId, string status, string notes);

        [OperationContract(Name = "ChangeIncidentReportOwner")]
        bool ChangeIncidentReportOwner(Contracts.DTO.User managerOrOwner, long incidentReportId, Contracts.DTO.User newOwner, string notes);

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

        [OperationContract(Name = "SaveIncidentReportComment")]
        IncidentReportWrapper SaveIncidentReportComment(long incidentReportId, string comment);

       
        [OperationContract(Name = "RemoveResource")]
        bool RemoveResource(ResourceData data);

        [OperationContract(Name = "GetResource")]
        ResourceData GetResource(ResourceData data);

        [OperationContract(Name = "GetCameraPlayDateTime")]
        string GetCameraPlayDateTime(long cameraId,long reportId);

        [OperationContract(Name = "GetVideoResource")]
        ResourceData GetVideoResource(ResourceData data);
           

        [OperationContract(Name = "AddResource")]
        ResourceData AddResource(ResourceData data);

        [OperationContract(Name = "AddVideoResource")]
        ResourceData AddVideoResource(ResourceData data);

        [OperationContract(Name = "GetIncidentReportByIDWeb")]
        List<IncidentReportWrapper> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);


        [OperationContract(Name = "GetIncidentReportById")]   //trupti14Sept15
        IncidentReportWrapper GetIncidentReportById(long IncidentReportId);

        [OperationContract(Name = "GetIncidentReportAlertDetails")]   //trupti 23 Feb 16
        IncidentReportAlertDTO GetIncidentReportAlertDetails(long IncidentReportId, long AlertId);     


    }
}
