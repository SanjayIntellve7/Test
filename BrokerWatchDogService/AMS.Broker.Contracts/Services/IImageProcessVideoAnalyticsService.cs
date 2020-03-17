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
    public interface IImageProcessVideoAnalyticsService
    {
        [OperationContract]
        bool ConsumeImageProcess(ImagebyteDto _ImagebyteDto);

        [OperationContract]
        bool ConsumeImageProcessTest(string deviceID,string AnalyticsType);

        [OperationContract]
        bool ConsumeLineCrossImageProcess(LineCrossImageDTO _ImagebyteDto);
    }
}
