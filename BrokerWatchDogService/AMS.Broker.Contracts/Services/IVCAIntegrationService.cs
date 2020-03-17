using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IVCAIntegrationService
    {
        [OperationContract]
        void Test();

        [OperationContract]
        string ConsumeVCAAlert(string ErrorCode, string CameraName, string strDateTime, string strTopLeftX, string strTopLeftY, string strBottomRightX, string strBottomRightY);

        [OperationContract]
        string ConsumeVCAImage(Stream  Image);

        [OperationContract]
        string ConsumeVCAAbandonedAlert(string ErrorCode, string CameraName, string strDateTime, string strTopLeftX, string strTopLeftY, string strBottomRightX, string strBottomRightY);
    }
}
