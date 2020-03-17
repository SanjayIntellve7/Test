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
    public interface ISOPSetOperationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        tblStandardSOPMasterDTO SaveSOPMasterData(tblStandardSOPMasterDTO SOPMasterData, string AuthToken);

        [OperationContract]
        tblSOPStepDataDTO SaveSOPStepData(tblSOPStepDataDTO SOPStepData, string AuthToken);

        [OperationContract]
        bool DeleteSOPStepData(string SOPStepId, string AuthToken);

        [OperationContract]
        bool DisableSOP(string SOPId, string AuthToken);

        [OperationContract]
        bool EnableSOP(string SOPId, string AuthToken);

        [OperationContract]
        bool UpdateSOPStepStatus(string StatusId, string AuthToken);

        [OperationContract]
        bool StopSOPTransaction(string TransactionId,string SOPComment, string AuthToken);

        [OperationContract]
        bool StartSOPTransaction(string TransactionId, string AuthToken);
    }
}
