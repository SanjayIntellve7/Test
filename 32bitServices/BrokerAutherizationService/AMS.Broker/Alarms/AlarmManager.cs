using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker
{
    public class AlarmManager
    {

        public AlarmManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            try
            {
                StartAlarmService();
            }
            catch (Exception e)
            {
                _logger.Log("AlarmManager : " + e.ToString());
            }
        }

        public AlarmService Service { get { return _alarmService; } }

        private void StartAlarmService()
        {
            if (_alarmService == null)
            {
                _alarmService = new AlarmService(_logger);
                _alarmService.PingReceived += OnPingReceived;
                _alarmService.DisconnectReceived += OnDisconnectReceived;
            }

            if (_wcfServiceHost != null) { _wcfServiceHost.Close(); }


            _logger.Log("");
            _logger.Log("------------------------------------");
            _logger.Log("starting alarm service ..");

            _wcfServiceHost = new ServiceHost(_alarmService);

            _wcfServiceHost.Open();

            _logger.Log(string.Format("listening at {0}", _wcfServiceHost.Description.Endpoints[0].ListenUri));
            _logger.Log("------------------------------------");
            _logger.Log("");
           
        }

        private void OnDisconnectReceived()
        {
            //if (StopReceived != null) StopReceived();
        }

        private void OnPingReceived()
        {
            _suspendCommunication = false;
        }

        private ServiceHost _wcfServiceHost = null;
        
        private ILogger _logger;

        private AlarmService _alarmService;

        private bool _suspendCommunication = false;

    }
}
