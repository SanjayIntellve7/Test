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
    public interface ISystemSOPService
    {
        [OperationContract]
        bool SendEmailNotification(Alert _alert);

        [OperationContract]
        bool SendSMSNotification(Alert _alert);

        [OperationContract]
        bool ExecuteAppiyoWorkFlow(Alert _alert);

        [OperationContract]
        void ProcessSOP(Alert _alert);
        //[OperationContract]
       // bool ActivatePA(Alert _alert);

       // [OperationContract]
       // bool PopulateNearByCameras();
    }
}
