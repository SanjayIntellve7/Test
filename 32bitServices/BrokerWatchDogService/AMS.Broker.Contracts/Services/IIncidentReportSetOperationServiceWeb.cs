using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{

    [ServiceContract]
    public interface IIncidentReportSetOperationServiceWeb
    {
        [OperationContract]
        bool ChangeIncidentReportOwnerWeb(string oldOwnerName, string oldOwnerAuthToken, long incidentReportId, string newOwnerName, string newOwnerAuthToken, string notes);
    }
}
