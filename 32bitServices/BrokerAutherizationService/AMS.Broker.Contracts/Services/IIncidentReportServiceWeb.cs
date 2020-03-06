using System;
using System.Collections.Generic;
using System.ServiceModel;
using IncidentReportDTO = AMS.Broker.Contracts.DTO.IncidentReport;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIncidentReportServiceWeb
    {
        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportsByOwnerWeb(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName);

        [OperationContract]
        bool ChangeIncidentReportOwnerWeb(string oldOwnerName, string oldOwnerAuthToken, long incidentReportId, string newOwnerName, string newOwnerAuthToken, string notes);

        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);
    }
}

