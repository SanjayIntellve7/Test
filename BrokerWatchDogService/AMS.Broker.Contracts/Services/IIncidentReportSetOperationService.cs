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
    public interface IIncidentReportSetOperationService
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

        [OperationContract(Name = "AddOperatorResponceToIncidentReport")]
        IncidentReportWrapper AddOperatorResponceToIncidentReport(User user, long incidentReportId, Guid resourceId, DateTime appendDate);

        [OperationContract(Name = "RemoveResourceFromIncidentReport")]
        IncidentReportWrapper RemoveResourceFromIncidentReport(User user, long incidentReportId, Guid resourceId);

        [OperationContract(Name = "RemoveOperatorResponseFromIncidentReport")]
        IncidentReportWrapper RemoveOperatorResponseFromIncidentReport(User user, long incidentReportId, Guid resourceId);

        [OperationContract(Name = "UpdateIncidentReportStatus")]
        bool UpdateIncidentReport(Contracts.DTO.User user, long incidentReportId, string status, string notes);

        [OperationContract(Name = "ChangeIncidentReportOwner")]
        bool ChangeIncidentReportOwner(Contracts.DTO.User managerOrOwner, long incidentReportId, Contracts.DTO.User newOwner, string notes);

        [OperationContract(Name = "SaveIncidentReportComment")]
        IncidentReportWrapper SaveIncidentReportComment(long incidentReportId, string comment, User user);


        [OperationContract(Name = "RemoveResource")]
        bool RemoveResource(ResourceData data);


        [OperationContract(Name = "AddResource")]
        ResourceData AddResource(ResourceData data);

        [OperationContract(Name = "AddVideoResource")]
        ResourceData AddVideoResource(ResourceData data);

    }
}
