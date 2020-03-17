using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AMS.Broker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)] // THIS SLOWS US DOWN
    public class DeviceService : IDeviceService
    {
        public DeviceService(ILogger logger)
        {
            _logger = logger;
        }
        public void NotifySetCamera(string systemId, string clientId, string cameraId, int gridX, int gridY)
        {


            _logger.Log("DeviceService received SetCamera : " + systemId + ", " + clientId + ", " + cameraId);

            // get the client identified by the systemId / clientId here ..
            if (_clients.Keys.Contains(clientId))
            {

                _logger.Log(clientId + " client found in active connections.");

                var client = _clients[clientId];

                try
                {
                    client.ReceiveSetCameraRequest(cameraId, gridX, gridY);

                    _logger.Log("SetCameraRequest sent");

                }
                catch (TimeoutException tex)
                {
                    _logger.Log(tex.Message);
                }
                catch (CommunicationException cex)
                {
                    // client disconnected? remove?
                    _logger.Log(cex.Message);
                }
            }
            else
            {
                _logger.Log(clientId + " client not found in active connections.");
            }

        }

        public void Ping(string systemId, string clientId)
        {
            var client = OperationContext.Current.GetCallbackChannel<IVideoOutputDeviceClient>();

            if (!_clients.Keys.Contains(clientId))
            {
                _clients.Add(clientId, client);

                ICommunicationObject commObj = client as ICommunicationObject;
                if (commObj != null)
                {
                    commObj.Closed += CommunicationLost;
                    commObj.Faulted += CommunicationLost;
                }
            }


            _logger.Log("Ping received at " + DateTime.Now.ToLongTimeString() + " from " + clientId);

            if (PingReceived != null) PingReceived();

            try
            {
                client.Pong();
            }
            catch (Exception ex)
            {
                _logger.Log("Pong Failed: " + clientId + " : " + ex.Message);
            }

        }

        public void Disconnect(string systemId, string clientId)
        {
            var client = OperationContext.Current.GetCallbackChannel<IVideoOutputDeviceClient>();

            if (!_clients.Keys.Contains(clientId))
            {
                _clients.Add(clientId, client);
            }

            _logger.Log("Disconnect received at " + DateTime.Now.ToLongTimeString());

            if (DisconnectReceived != null) DisconnectReceived();

        }

        public event Action PingReceived;
        public event Action DisconnectReceived;

        public void NotifyInfo(string info)
        {
            try
            {
                //client.ReceiveInfo(info);
            }
            catch (TimeoutException)
            {
                // don't crash because of this
            }
            catch (CommunicationException)
            {
                // remove client?
            }
        }
        public void NotifyError(string error)
        {
            try
            {
                //_client.ReceiveError(error);
            }
            catch (TimeoutException)
            {

            }
            catch (CommunicationException)
            {
                // remove client?
            }

        }

        private void CommunicationLost(object sender, EventArgs e)
        {

            IVideoOutputDeviceClient callback = sender as IVideoOutputDeviceClient;
            if (callback != null)
            {

                _logger.Log("Communication has been lost");

                //if (_clients.Keys.Contains(callback.))
                //{

                //    ICommunicationObject commObj = callback as ICommunicationObject;
                //    if (commObj != null)
                //    {
                //        //remove the reference to the event handle to help memory cleanup
                //        commObj.Closed -= new EventHandler(client_Closed);
                //    }
                //    //_clients.Remove(callback);
                //}
            }
        }

        private ILogger _logger;
        private Dictionary<string, IVideoOutputDeviceClient> _clients = new Dictionary<string, IVideoOutputDeviceClient>();
    }
}
