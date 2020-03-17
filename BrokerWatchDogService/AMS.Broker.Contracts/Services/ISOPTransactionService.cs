using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISOPTransactionService
    {
        [OperationContract]
        bool UpdateSOPStepExecution(int stepId, int SOPId, long alertId);

        [OperationContract]
        int ExecuteSOPAction(string ActionName, int step, int SOPId, long alertId, string authToken);
    }
}
