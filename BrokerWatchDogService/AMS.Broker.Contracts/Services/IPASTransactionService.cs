using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IPASTransactionService
    {
        [OperationContract]
        string SetMultiPADevVoiceTransaction(string AllSelectedDevId, int PrerecordedFileId, Guid authToken); //harsha290619 SmartCity

        [OperationContract]
        void CallSingle(string devID, string PAClientID, Guid authToken); //harsha290619 SmartCity

        [OperationContract]
        void DisconnectCall(string devID, string PAClientID, Guid authToken); //harsha290619 SmartCity

        [OperationContract]
        void CallGroup(string devID, string PAClientID, Guid authToken);

        [OperationContract]
        string StopPrerecordedmessageTransaction(string AllSelectedDevId, int PrerecordedFileId, Guid authToken); //harsha290619 SmartCity

    }
}