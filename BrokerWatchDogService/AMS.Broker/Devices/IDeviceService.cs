using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts;

namespace AMS.Broker
{
    [ServiceContract(Namespace = "", CallbackContract = typeof(IVideoOutputDeviceClient), SessionMode = SessionMode.Required)]
    public interface IDeviceService
    {
        [OperationContract(IsOneWay = true)]
        void Ping(string systemId, string clientId);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string systemId, string clientId);
    }

    [ServiceContract]
    public interface IVideoOutputDeviceClient
    {
        [OperationContract(IsOneWay = true)]
        void Pong();

        [OperationContract(IsOneWay = true)]
        void ReceiveInfo(string info);

        [OperationContract(IsOneWay = true)]
        void ReceiveError(string error);

        [OperationContract(IsOneWay = true)]
        void ReceiveSetCameraRequest(string cameraId, int gridX, int gridY);
    }
}
