using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISMSEmailNotificationService
    {
        [OperationContract]
        bool SendBulkEmail(List<string> AllEmailList, string authToken, string strMessage);
        [OperationContract]
        bool SendBulkSMSNotification(List<string> AllEmailList, string authToken, string strMessage);
        [OperationContract]
        bool Test();
    }

}
