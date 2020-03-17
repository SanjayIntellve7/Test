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
    public interface IMannapuramAlertCreationService
    {
       // [OperationContract]
       // void CreateMannapuramAlert(DeviceDto _DeviceDto, string strEventCode, string Serverity, string AlertdateTime, string strHeadline, int tblEventID);

        [OperationContract]
        void startAlertRuleProcess(string PatriotTableID, string Client_no, string BranchID, string externalid, string eventcode, string AlertdateTime, string Description, int tblEventID,  string PartitionNo);  // jatin 12032019

        [OperationContract]
        List<OpenCloseEventRuleDefDTO> GetOpeningClosingRuleCollection();        

    }
}
