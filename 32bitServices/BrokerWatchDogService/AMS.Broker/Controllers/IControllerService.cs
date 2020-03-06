using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts;

using DeviceDTO = AMS.Broker.Contracts.Device;

namespace AMS.Broker
{
    [ServiceContract]
    public interface IControllerService
    {
        event Action<string, string, string, int, int> SetCameraRequest;

        //[OperationContract]
        //string CreateSession(string systemId, string username, string password);

        [OperationContract]
        bool SetCamera(string systemId, string token, string clientId, string cameraId, string gridX, string gridY);

        [OperationContract]
        bool Test();

        [OperationContract]
        IEnumerable<DeviceDTO> GetList(string authToken, string clientId);
    }
}
