using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ICameraEventListenerService
    {
        [OperationContract]
        int CosumeCameraEventListenerAlert(string deviceIP, string errorCode, string dateTime, string AlgoName, byte[] managedArray);
    }

}
