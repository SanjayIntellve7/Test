using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IEmailNotificationService
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        void SendEmailNotification(string Message, string Receiver);

        [OperationContract]
        void SendEventEmail(string strMessage, int eventCode);

        [OperationContract]
        bool SendBulkEmail(List<string> AllEmailList, string authToken, string strMessage);
    }
}
