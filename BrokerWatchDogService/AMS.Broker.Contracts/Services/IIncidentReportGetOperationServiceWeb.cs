using System;
using System.Collections.Generic;
using System.ServiceModel;
using IncidentReportDTO = AMS.Broker.Contracts.DTO.IncidentReport;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IIncidentReportGetOperationServiceWeb
    {
        [OperationContract]
        IEnumerable<IncidentReportDTO> GetIncidentReportsByOwnerWeb(string userName, string authToken, string startCreateDate, string endCreateDate, string ownerUserName);
    
        [OperationContract]
        List<IncidentReportDTO> GetIncidentReportByIDWeb(string authToken, int IncidentReportId);
    }
}

