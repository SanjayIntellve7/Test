using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface INvrCamerasService
    {
        [OperationContract]
        IEnumerable<DeviceDto> GetCameras(string nvr);

        [OperationContract]
        IEnumerable<DeviceDto> GetCamerasByNvr(NvrDto nvr);
    }
}
