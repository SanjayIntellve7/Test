using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker
{

    [ServiceContract(Namespace = "", CallbackContract = typeof(IVideoOutputDeviceClient))]
    public interface IWCFService
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
        void ReceiveSetCameraRequest(string systemId, string cameraId, string gridRef);

    }

}
