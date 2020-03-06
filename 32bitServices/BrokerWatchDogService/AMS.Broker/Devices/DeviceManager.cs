using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker
{
    public class DeviceManager
    {
        public DeviceManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            try
            {

                StartCrossDomain();

                StartDeviceService();
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString());

            }

        }

        public DeviceService Service { get { return _deviceService; } }

        private void StartDeviceService()
        {
            if (_deviceService == null)
            {
                _deviceService = new DeviceService(_logger);
                _deviceService.PingReceived += OnPingReceived;
                _deviceService.DisconnectReceived += OnDisconnectReceived;
            }

            if (_wcfServiceHost != null) { _wcfServiceHost.Close(); }


            _logger.Log("");
            _logger.Log("------------------------------------");
            _logger.Log("starting device service ..");

            _wcfServiceHost = new ServiceHost(_deviceService);

            _wcfServiceHost.Open();

            _logger.Log(string.Format("listening at {0}", _wcfServiceHost.Description.Endpoints[0].ListenUri));
            _logger.Log("------------------------------------");
            _logger.Log("");
           
        }

        private void StartCrossDomain()
        {
            if (_crossDomainService == null) { _crossDomainService = new CrossDomainService(); }

            _crossServiceHost = new ServiceHost(_crossDomainService);

            _crossServiceHost.Open();

        }

        private void OnDisconnectReceived()
        {
            if (StopReceived != null) StopReceived();
        }

        private void OnPingReceived()
        {
            _suspendCommunication = false;
        }

        public void Stop()
        {

            if (_crossServiceHost != null)
            {
                _crossServiceHost.Close();
                _crossServiceHost = null;
            }

            if (_wcfServiceHost != null)
            {
                _wcfServiceHost.Close();
                _wcfServiceHost = null;
            }
        }
    
        public void NotifyInfo(string info)
        {
            
        }

        public void NotifyError(string error)
        {
            
        }

        public event Action CommunicationError;
        public event Action StopReceived;

        private ServiceHost _wcfServiceHost = null;
        private ServiceHost _crossServiceHost = null;

        private ILogger _logger;

        private DeviceService _deviceService;
        private CrossDomainService _crossDomainService;

        private bool _suspendCommunication = false;
    }
}
