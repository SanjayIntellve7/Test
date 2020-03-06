using System.Collections.Generic;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Interfaces
{
    public interface INvrCamerasProvider
    {
        IEnumerable<DeviceDto> GetCameras(NvrDto nvrDto);
        IEnumerable<object> GetCameraAdditionalInfo(NvrDto nvr);
    }
}
