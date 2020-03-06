using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;

namespace AMS.Broker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)] // THIS SLOWS US DOWN
    public class WCFService : IWCFService
    {

        public WCFService(ILogger logger)
        {
            _logger = logger;
        }


        public void NotifySetCamera(string systemId, string clientId, string cameraId, string gridRef)
        {

            // get the client identified by the systemId / clientId here ..

            if (_client != null)
            {
                _client.ReceiveSetCameraRequest(systemId, cameraId, gridRef);
            }



        }

        public void Ping(string systemId, string clientId)
        {
            _client = OperationContext.Current.GetCallbackChannel<IVideoOutputDeviceClient>();

            _logger.Log("Ping received at " + DateTime.Now.ToLongTimeString() + " from " + clientId);

            if (PingReceived != null) PingReceived();

            _client.Pong();

        }

        public void Disconnect(string systemId, string clientId)
        {
            _client = OperationContext.Current.GetCallbackChannel<IVideoOutputDeviceClient>();

            _logger.Log("Disconnect received at " + DateTime.Now.ToLongTimeString());

            if (DisconnectReceived != null) DisconnectReceived();

        }

        //public event Action<MeasurementProgram> ProgramReceived;
        public event Action PingReceived;
        public event Action DisconnectReceived;


        private IVideoOutputDeviceClient _client;


        public void NotifyInfo(string info)
        {
            try
            {
                _client.ReceiveInfo(info);
            }
            catch (TimeoutException)
            {
                // don't crash because of this
            }
        }

        public void NotifyError(string error)
        {
            try
            {
                _client.ReceiveError(error);
            }
            catch (TimeoutException)
            {

            }

        }

        private ILogger _logger;
    }
}
