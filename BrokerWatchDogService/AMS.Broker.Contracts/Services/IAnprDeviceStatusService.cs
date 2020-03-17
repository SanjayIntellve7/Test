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
    public interface IAnprDeviceStatusService
    {
        [OperationContract]
        void Test();

        [OperationContract]
        List<AnprStatusDto> GetAnprDeviceStatusCollection(string authToken);
     
        [OperationContract]
        string ConsumeAnprDeviceStatusDataLP(ANPRLPDetails anprLPStatus);

        [OperationContract]
        string ConsumeAnprDeviceStatusDataCam(ANPRCameraDetails anprCamStatus);
    }
}
